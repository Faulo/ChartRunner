using System;
using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class AvatarController : MonoBehaviour {
    [Header("MonoBehaviour configuration")]
    [SerializeField, Expandable]
    Rigidbody2D attachedRigidbody = default;

    [Header("Movement")]
    [SerializeField, Range(0, 20)]
    float movementSpeed = 10;
    [SerializeField, Range(0, 2)]
    float accelerationDuration = 1;
    [SerializeField, Range(0, 20)]
    float jumpStartSpeed = 10;
    [SerializeField, Range(0, 20)]
    float jumpStopSpeed = 2;

    float acceleration = 0;
    bool isJumping = false;

    [Header("Input")]
    public float intendedMovement;
    public bool intendsJumpStart;
    public bool intendsJump;

    void FixedUpdate() {
        float targetSpeed = intendedMovement * movementSpeed;
        var velocity = attachedRigidbody.velocity;
        if (Math.Sign(targetSpeed) != Math.Sign(velocity.x)) {
            // instant break if direction changes
            velocity.x = 0;
            acceleration = 0;
        }
        velocity.x = Mathf.SmoothDamp(velocity.x, targetSpeed, ref acceleration, accelerationDuration);
        if (isJumping) {
            if (!intendsJump) {
                isJumping = false;
                velocity.y = Mathf.Min(velocity.y, jumpStopSpeed);
            }
        } else {
            if (intendsJumpStart) {
                intendsJumpStart = false;
                isJumping = true;
                velocity.y = Mathf.Max(velocity.y, jumpStartSpeed);

                Statistics.instance.Add(IntStatistic.Jumps, 1);
            }
        }
        attachedRigidbody.velocity = velocity;

        Statistics.instance.Add(Vector2Statistic.VelocityOverTime, velocity);
        Statistics.instance.Add(FloatStatistic.TimePassed, Time.deltaTime);
    }

    void OnValidate() {
        if (!attachedRigidbody) {
            attachedRigidbody = GetComponentInParent<Rigidbody2D>();
        }
    }
}
