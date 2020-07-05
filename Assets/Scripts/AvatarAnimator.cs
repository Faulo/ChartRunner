using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class AvatarAnimator : MonoBehaviour {
    enum Parameter {
        IsRunning,
        TakeOff,
        IsJumping,
        IsGrounded,
        FaceDirection,
        StartRoll,
    }
    [SerializeField, Expandable]
    AvatarController observedAvatar = default;
    [SerializeField, Expandable]
    Animator observedAnimator = default;

    void Start() {
        observedAvatar.onJump.AddListener(data => observedAnimator.SetTrigger(nameof(Parameter.TakeOff)));
        observedAvatar.onRoll.AddListener(data => observedAnimator.SetTrigger(nameof(Parameter.StartRoll)));
        Rewind.instance.onCollectCommands += CollectCommands;
    }

    void CollectCommands(ICollection<IUndoable> commands) {
        var state = observedAnimator.GetCurrentAnimatorClipInfo(0)[0];
        commands.Add(new DictionaryStatisticCommand(DictionaryStatistic.AnimatorState, state.clip.name, Time.deltaTime));
    }

    void Update() {
        observedAnimator.SetBool(nameof(Parameter.IsRunning), observedAvatar.isRunning);
        observedAnimator.SetBool(nameof(Parameter.IsJumping), observedAvatar.isJumping);
        observedAnimator.SetBool(nameof(Parameter.IsGrounded), observedAvatar.isGrounded);
        observedAnimator.SetFloat(nameof(Parameter.FaceDirection), observedAvatar.facing);
    }
}
