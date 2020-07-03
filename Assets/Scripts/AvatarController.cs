using System;
using System.Collections;
using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Assertions;

public class AvatarController : MonoBehaviour {
    [Header("MonoBehaviour configuration")]
    [SerializeField, Expandable]
    Rigidbody2D attachedRigidbody = default;
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

    float acceleration = 0;

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

    bool isGrounded => state == AvatarState.Grounded;
    bool isJumping => state == AvatarState.Jumping;

    Vector3 previousPosition;
    void Start() {
        StartCoroutine(PositionSaver());
    }

    IEnumerator PositionSaver() {
        while (true) {
            previousPosition = transform.position;
            yield return new WaitForFixedUpdate();
        }
    }

    void FixedUpdate() {
        Audio.instance.playsForward = !intendsRewind;

        if (intendsRewind) {
            Rewind.instance.Undo();
            Rewind.instance.Undo();
        } else {
            var oldSnapshot = RecordSnapshot();
            var snapshot = new AvatarSnapshot();

            var commands = new List<IUndoable>();

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

                    commands.Add(new FloatStatisticCommand(FloatStatistic.Jumps, 1));
                }
            }

            Assert.AreEqual(oldSnapshot, RecordSnapshot(), "Avatar state MUST NOT change during FixedUpdate!");

            snapshot.position = transform.position;
            snapshot.state = newState;
            snapshot.acceleration = acceleration;
            snapshot.velocity = velocity;

            commands.Add(new FloatStatisticCommand(FloatStatistic.TimePassed, Time.deltaTime));
            commands.Add(new Vector2StatisticCommand(Vector2Statistic.VelocityOverTime, velocity.magnitude));
            commands.Add(new AvatarCommand(oldSnapshot, snapshot, ApplySnapshot));

            Rewind.instance.Do(commands);
        }
    }

    AvatarSnapshot RecordSnapshot() {
        return new AvatarSnapshot {
            position = previousPosition,
            velocity = attachedRigidbody.velocity,
            state = state,
            acceleration = acceleration
        };
    }
    void ApplySnapshot(AvatarSnapshot snapshot) {
        transform.position = snapshot.position;
        attachedRigidbody.velocity = snapshot.velocity;
        state = snapshot.state;
        acceleration = snapshot.acceleration;
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
}
