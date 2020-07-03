﻿using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvatarInput : MonoBehaviour, Controls.IPlayerActions {
    [SerializeField, Expandable]
    AvatarController avatar = default;

    Controls controls;

    public void OnMove(InputAction.CallbackContext context) {
        var input = context.ReadValue<Vector2>();
        avatar.intendedMovement = input.x;
    }
    public void OnJump(InputAction.CallbackContext context) {
        if (context.started) {
            avatar.intendsJumpStart = true;
        }
        avatar.intendsJump = context.performed;
        if (context.canceled) {
            avatar.intendsJumpStart = false;
        }
    }

    void Awake() {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
    }
    public void OnEnable() {
        controls.Player.Enable();
    }
    public void OnDisable() {
        controls.Player.Disable();
    }
    void OnValidate() {
        if (!avatar) {
            avatar = GetComponentInParent<AvatarController>();
        }
    }
}
