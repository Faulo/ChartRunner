using UnityEngine;

public class RewindEvents : MonoBehaviour {
    [SerializeField]
    GameObjectEvent onStartRewind = default;
    [SerializeField]
    GameObjectEvent onStopRewind = default;

    void Start() {
        Rewind.instance.onStartRewind += onStartRewind.Invoke;
        Rewind.instance.onStopRewind += onStopRewind.Invoke;
    }
}
