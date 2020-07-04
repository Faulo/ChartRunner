using Slothsoft.UnityExtensions;
using UnityEngine;

public class AvatarAnimator : MonoBehaviour {
    enum Parameter {
        IsRunning,
        TakeOff,
        IsJumping,
        IsGrounded,
        FaceDirection
    }
    [SerializeField, Expandable]
    AvatarController observedAvatar = default;
    [SerializeField, Expandable]
    Animator observedAnimator = default;

    void Start() {
        observedAvatar.onJump.AddListener(data => observedAnimator.SetTrigger(nameof(Parameter.TakeOff)));
    }

    void Update() {
        observedAnimator.SetBool(nameof(Parameter.IsRunning), observedAvatar.isRunning);
        observedAnimator.SetBool(nameof(Parameter.IsJumping), observedAvatar.isJumping);
        observedAnimator.SetBool(nameof(Parameter.IsGrounded), observedAvatar.isGrounded);
        observedAnimator.SetFloat(nameof(Parameter.FaceDirection), observedAvatar.facing);
    }
}
