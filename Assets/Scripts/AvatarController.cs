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
    [Header("Grounded Check")]
    [SerializeField, Expandable]
    Transform groundCheck = default;
    [SerializeField]
    Vector2 groundCheckSize = Vector2.one;
    [SerializeField]
    LayerMask groundCheckLayers = default;

    [Header("Movement")]
    [SerializeField, Range(0, 20)]
    float movementSpeed = 10;
    [SerializeField, Range(0, 2)]
    float accelerationDuration = 1;
    [SerializeField, Range(0, 20)]
    float jumpStartSpeed = 10;
    [SerializeField, Range(0, 20)]
    float jumpStopSpeed = 2;
    [SerializeField, Range(0, 10)]
    float gravity = 1;
    [SerializeField, Range(0, 20)]
    float isRunningThreshold = 1;

    float acceleration = 0;
    public float facing { get; private set; } = 1;

    [Header("Events")]
    [SerializeField]
    public GameObjectEvent onJump = default;
    [SerializeField]
    public GameObjectEvent onEnterGround = default;
    [SerializeField]
    public GameObjectEvent onExitGround = default;


    [Header("Input")]
    public float intendedMovement;
    public bool intendsJumpStart;
    public bool intendsJump;
    public bool intendsRewind;

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

    Vector3 previousPosition;
    void Start() {
        Statistics.instance.AddCalculator(FloatStatistic.CurrentX, () => attachedRigidbody.position.x);
        Statistics.instance.AddCalculator(FloatStatistic.CurrentY, () => attachedRigidbody.position.y);
        Statistics.instance.AddCalculator(FloatStatistic.CurrentSpeed, () => attachedRigidbody.velocity.magnitude);

        StartCoroutine(PositionSaver());

        Rewind.instance.onCollectCommands += CollectCommands;
        Rewind.instance.onStartRewind += StartRewindListener;
        Rewind.instance.onStopRewind += StopRewindListener;
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
        if (Math.Sign(targetSpeed) != Math.Sign(velocity.x)) {
            // instant break if direction changes
            velocity.x = 0;
            acceleration = 0;
        }
        velocity.x = Mathf.SmoothDamp(velocity.x, targetSpeed, ref acceleration, accelerationDuration);
        velocity += Physics2D.gravity * gravity * Time.deltaTime;
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

        float newFacing = Math.Sign(intendedMovement);

        Assert.AreEqual(oldSnapshot, RecordSnapshot(), "Avatar state MUST NOT change during FixedUpdate!");

        snapshot.position = transform.position;
        snapshot.state = newState;
        snapshot.acceleration = acceleration;
        snapshot.velocity = velocity;
        snapshot.facing = newFacing == 0
            ? facing
            : newFacing;

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
        };
    }
    void ApplySnapshot(AvatarSnapshot snapshot) {
        transform.position = snapshot.position;
        attachedRigidbody.velocity = snapshot.velocity;
        state = snapshot.state;
        acceleration = snapshot.acceleration;
        facing = snapshot.facing;
    }

    AvatarState CalculateState() {
        switch (state) {
            case AvatarState.Grounded:
            case AvatarState.Falling:
                if (Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundCheckLayers)) {
                    return AvatarState.Grounded;
                } else {
                    return AvatarState.Falling;
                }
            case AvatarState.Jumping:
                return AvatarState.Jumping;
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
