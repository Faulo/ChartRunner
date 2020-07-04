using UnityEngine;

[CreateAssetMenu(fileName = "Audio_New", menuName = "Effects/Play Audio")]
public class PlayAudioEffect : Effect {
    [SerializeField]
    AudioInfo audio = default;

    public override void Invoke(GameObject context) {
        Audio.instance.Play(audio);
    }
}