using System;
using System.Collections;
using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Assertions;

public class AvatarController : MonoBehaviour {
    [Header("MonoBehaviour configuration")]
    [SerializeField, Expandable]
    public Rigidbody2D attachedRigidbody = default;

    [Header("Ground Movement")]
    [SerializeField, Range(0, 20)]
    float movementSpeed = 10;
    [SerializeField, Range(1, 5)]
    float runMultiplier = 2;
    [SerializeField, Range(0, 2)]
    float walkAccelerationDuration = 1;
    [SerializeField, Range(0, 2)]
    float runAccelerationDuration = 1;
    [SerializeField, Range(0, 2)]
    float breakDecelerationDuration = 1;

    [Header("Jumping")]
    [SerializeField, Range(0, 20)]
    float jumpStartSpeed = 10;
    [SerializeField, Range(0, 20)]
    float jumpStopSpeed = 2;

    [Header("Rolling")]
    [SerializeField, Range(0, 20)]
    float rollStartSpeedX = 10;
    [SerializeField, Range(0, 20)]
    float rollStartSpeedY = 5;
    [SerializeField, Range(0, 5)]
    float rollDuration = 1;
    [SerializeField, Range(0, 5)]
    float rollDrag = 1;

    [Header("Misc")]
    [SerializeField, Range(0, 10)]
    float gravity = 1;
    [SerializeField, Range(0, 20)]
    float isRunningThreshold = 1;

    [Header("Grounded Check")]
    [SerializeField, Expandable]
    Transform groundCheck = default;
    [SerializeField]
    Vector2 groundCheckSize = Vector2.one;
    [SerializeField]
    LayerMask groundCheckLayers = default;


    float acceleration = 0;
    float rollTimer = 0;
    public float facing { get; private set; } = 1;

    [Header("Events")]
    [SerializeField]
    public GameObjectEvent onSpawn = default;
    [SerializeField]
    public GameObjectEvent onJump = default;
    [SerializeField]
    public GameObjectEvent onRoll = default;
    [SerializeField]
    public GameObjectEvent onEnterGround = default;
    [SerializeField]
    public GameObjectEvent onExitGround = default;

    [Header("Input")]
    public float intendedMovement;
    public bool intendsJumpStart;
    public bool intendsJump;
    public bool intendsRewind;
    public bool intendsRun;
    public bool intendsRollStart;

    AvatarState state {
        get => stateCache;
        set {
            if (stateCache != value) {
                stateCache = value;
            }
        }
    }
    public AvatarState stateCache;

    public bool isGrounded => state == AvatarState.Grounded;
    public bool isJumping => state == AvatarState.Jumping;
    public bool isRunning => isGrounded && Mathf.Abs(attachedRigidbody.velocity.x) > isRunningThreshold;
    public bool isRolling => state == AvatarState.Rolling;

    Vector3 previousPosition;
    void Start() {
        Statistics.instance.AddCalculator(FloatStatistic.CurrentX, () => attachedRigidbody.position.x);
        Statistics.instance.AddCalculator(FloatStatistic.CurrentY, () => attachedRigidbody.position.y);
        Statistics.instance.AddCalculator(FloatStatistic.CurrentSpeed, () => attachedRigidbody.velocity.magnitude);

        StartCoroutine(PositionSaver());

        Rewind.instance.onCollectCommands += CollectCommands;
        Rewind.instance.onStartRewind += StartRewindListener;
        Rewind.instance.onStopRewind += StopRewindListener;

        state = AvatarState.FirstFrame;
    }


    void StartRewindListener(GameObject context) {
        attachedRigidbody.simulated = false;
    }
    void StopRewindListener(GameObject context) {
        attachedRigidbody.simulated = true;
    }

    IEnumerator PositionSaver() {
        while (true) {
            previousPosition = transform.position;
            yield return new WaitForFixedUpdate();
        }
    }

    void CollectCommands(ICollection<IUndoable> commands) {
        var oldSnapshot = RecordSnapshot();
        var snapshot = new AvatarSnapshot();

        var newState = CalculateState();

        float acceleration = snapshot.acceleration;
        float targetSpeed = intendedMovement * movementSpeed;

        var velocity = attachedRigidbody.velocity;

        velocity += Physics2D.gravity * gravity * Time.deltaTime;

        if (newState == AvatarState.FirstFrame) {
            newState = AvatarState.Grounded;
            commands.Add(new EventCommand(gameObject, onSpawn));
        } else {
            if (newState == AvatarState.Rolling) {
                snapshot.drag = rollDrag;
                snapshot.rollTimer = rollTimer - Time.deltaTime;
            } else {
                snapshot.drag = 0;

                if (Math.Sign(targetSpeed) != Math.Sign(velocity.x)) {
                    // instant break if direction changes
                    velocity.x = 0;
                    acceleration = 0;
                }

                bool isAccelerating = Math.Abs(velocity.x) < Math.Abs(targetSpeed);
                float accelerationDuration = 0;
                if (intendsRun) {
                    accelerationDuration = isAccelerating
                        ? walkAccelerationDuration
                        : runAccelerationDuration;
                    targetSpeed *= runMultiplier;
                } else {
                    accelerationDuration = isAccelerating
                        ? walkAccelerationDuration
                        : breakDecelerationDuration;
                }

                velocity.x = Mathf.SmoothDamp(velocity.x, targetSpeed, ref acceleration, accelerationDuration);

                if (newState == AvatarState.Jumping) {
                    if (!intendsJump || velocity.y < jumpStopSpeed) {
                        newState = AvatarState.Falling;
                        velocity.y = Mathf.Min(velocity.y, jumpStopSpeed);
                    }
                } else {
                    if (intendsJumpStart && newState == AvatarState.Grounded) {
                        intendsJumpStart = false;
                        newState = AvatarState.Jumping;
                        velocity.y = Mathf.Max(velocity.y, jumpStartSpeed);
                        commands.Add(new EventCommand(groundCheck.gameObject, onJump));
                        commands.Add(new FloatStatisticCommand(FloatStatistic.Jumps, 1));
                    }
                }

                if (intendsRollStart) {
                    intendsRollStart = false;
                    newState = AvatarState.Rolling;
                    velocity += new Vector2(facing * rollStartSpeedX, rollStartSpeedY);
                    snapshot.rollTimer = rollDuration;
                    commands.Add(new EventCommand(groundCheck.gameObject, onRoll));
                    commands.Add(new FloatStatisticCommand(FloatStatistic.Rolls, 1));
                }
            }
        }



        float newFacing = Math.Sign(intendedMovement);

        Assert.AreEqual(oldSnapshot, RecordSnapshot(), "Avatar state MUST NOT change during FixedUpdate!");

        snapshot.position = transform.position;
        snapshot.state = newState;
        snapshot.acceleration = acceleration;
        snapshot.velocity = velocity;
        snapshot.facing = newFacing == 0
            ? facing
            : newFacing;

        float deltaMaxSpeed = velocity.magnitude - Statistics.instance.Get(FloatStatistic.MaximumSpeed);
        if (deltaMaxSpeed > 0) {
            commands.Add(new FloatStatisticCommand(FloatStatistic.MaximumSpeed, deltaMaxSpeed));
        }

        commands.Add(new FloatStatisticCommand(FloatStatistic.TimePassed, Time.deltaTime));
        commands.Add(new Vector2StatisticCommand(Vector2Statistic.VelocityOverTime, velocity.magnitude));
        commands.Add(new AvatarCommand(oldSnapshot, snapshot, ApplySnapshot));

        if (snapshot.state == AvatarState.Grounded) {
            commands.Add(new FloatStatisticCommand(FloatStatistic.GroundedTime, Time.deltaTime));
        } else {
            commands.Add(new FloatStatisticCommand(FloatStatistic.AirborneTime, Time.deltaTime));
        }

        if (snapshot.state == AvatarState.Grounded && oldSnapshot.state != AvatarState.Grounded) {
            commands.Add(new EventCommand(groundCheck.gameObject, onEnterGround));
        }
        if (snapshot.state != AvatarState.Grounded && oldSnapshot.state == AvatarState.Grounded) {
            commands.Add(new EventCommand(groundCheck.gameObject, onExitGround));
        }
        commands.Add(new Vector2StatisticCommand(Vector2Statistic.CurrentPosition, snapshot.position));
    }

    AvatarSnapshot RecordSnapshot() {
        return new AvatarSnapshot {
            position = previousPosition,
            velocity = attachedRigidbody.velocity,
            state = state,
            acceleration = acceleration,
            facing = facing,
            drag = attachedRigidbody.drag,
            rollTimer = rollTimer,
        };
    }
    void ApplySnapshot(AvatarSnapshot snapshot) {
        transform.position = snapshot.position;
        attachedRigidbody.velocity = snapshot.velocity;
        state = snapshot.state;
        acceleration = snapshot.acceleration;
        facing = snapshot.facing;
        attachedRigidbody.drag = snapshot.drag;
        rollTimer = snapshot.rollTimer;
    }

    AvatarState CalculateState() {
        switch (state) {
            case AvatarState.FirstFrame:
                return AvatarState.FirstFrame;
            case AvatarState.Grounded:
            case AvatarState.Falling:
                if (Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundCheckLayers)) {
                    return AvatarState.Grounded;
                } else {
                    return AvatarState.Falling;
                }
            case AvatarState.Jumping:
                return AvatarState.Jumping;
            case AvatarState.Rolling:
                if (rollTimer > 0) {
                    return AvatarState.Rolling;
                }
                goto case AvatarState.Falling;
            default:
                throw new NotImplementedException(state.ToString());
        }
    }

    void OnValidate() {
        if (!attachedRigidbody) {
            attachedRigidbody = GetComponentInParent<Rigidbody2D>();
        }
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, new Vector3(groundCheckSize.x, groundCheckSize.y, 0));
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.attachedRigidbody && collider.attachedRigidbody.TryGetComponent<IInteractable>(out var interact)) {
            interact.Interact();
        }
    }
}
