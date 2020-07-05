using UnityEngine;

[CreateAssetMenu(fileName = "KillAvatar_New", menuName = "Effects/KillAvatar")]
public class KillAvatarEffect : Effect {
    public override void Invoke(GameObject context) {
        var avatar = FindObjectOfType<AvatarController>();
        if (avatar) {
            avatar.isComatose = !Rewind.instance.isRewinding;
        }
    }
}
