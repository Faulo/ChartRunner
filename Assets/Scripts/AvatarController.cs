using System;
using Slothsoft.UnityExtensions;
using UnityEngine;

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

    void FixedUpdate() {
        state = CalculateState();

        float targetSpeed = intendedMovement * movementSpeed;
        var velocity = attachedRigidbody.velocity;
        if (Math.Sign(targetSpeed) != Math.Sign(velocity.x)) {
            // instant break if direction changes
            velocity.x = 0;
            acceleration = 0;
        }
        velocity.x = Mathf.SmoothDamp(velocity.x, targetSpeed, ref acceleration, accelerationDuration);
        velocity += Physics2D.gravity * gravity * Time.deltaTime;
        if (isJumping) {
            if (!intendsJump || velocity.y < jumpStopSpeed) {
                state = AvatarState.Falling;
                velocity.y = Mathf.Min(velocity.y, jumpStopSpeed);
            }
        } else {
            if (intendsJumpStart && isGrounded) {
                intendsJumpStart = false;
                state = AvatarState.Jumping;
                velocity.y = Mathf.Max(velocity.y, jumpStartSpeed);

                Statistics.instance.Add(FloatStatistic.Jumps, 1);
            }
        }
        attachedRigidbody.velocity = velocity;

        Statistics.instance.Add(FloatStatistic.TimePassed, Time.deltaTime);
        Statistics.instance.Add(Vector2Statistic.VelocityOverTime, velocity.magnitude);
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
