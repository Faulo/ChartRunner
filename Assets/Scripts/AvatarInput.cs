using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvatarInput : MonoBehaviour, Controls.IPlayerActions {
    [SerializeField, Expandable]
    AvatarController avatar = default;

    Controls controls;

    public void OnMove(InputAction.CallbackContext context) {
        avatar.intendedMovement = context.ReadValue<float>();
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
    public void OnRewind(InputAction.CallbackContext context) {
        avatar.intendsRewind = context.performed;
        Rewind.instance.isRewinding = context.performed;
    }
    public void OnRun(InputAction.CallbackContext context) {
        avatar.intendsRun = context.performed;
    }
    public void OnRoll(InputAction.CallbackContext context) {
        if (context.started) {
            avatar.intendsRollStart = true;
        }
        avatar.intendsRoll = context.performed;
        if (context.canceled) {
            avatar.intendsRollStart = false;
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
