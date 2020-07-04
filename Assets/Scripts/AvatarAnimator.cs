using Slothsoft.UnityExtensions;
using UnityEngine;

public class AvatarAnimator : MonoBehaviour {
    enum Parameter {
        IsRunning,
        TakeOff,
        IsJumping
    }
    [SerializeField, Expandable]
    AvatarController observedAvatar = default;
    [SerializeField, Expandable]
    Animator observedAnimator = default;

    void Update() {
        observedAnimator.SetBool(nameof(Parameter.IsJumping), observedAvatar.isJumping);
        observedAnimator.SetBool(nameof(Parameter.IsRunning), observedAvatar.isRunning);
    }
}
