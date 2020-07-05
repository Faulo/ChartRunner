using UnityEngine;

public class Goal : MonoBehaviour, IInteractable {
    [SerializeField]
    GameObjectEvent onActivate = default;

    public void Interact() {
        onActivate.Invoke(gameObject);
    }
}
