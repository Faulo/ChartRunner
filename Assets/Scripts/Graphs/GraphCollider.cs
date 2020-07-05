using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Assertions;

public class GraphCollider : MonoBehaviour {
    [Header("References")]
    [SerializeField, Expandable]
    Collider2D attachedCollider = default;

    IGraphComponent parent;

    public GraphCollisionMode collisionMode => parent.collisionMode;

    void Start() {
        parent = GetComponentInParent<IGraphComponent>();
        Assert.IsNotNull(parent);

        OnValidate();

        if (attachedCollider) {
            switch (collisionMode) {
                case GraphCollisionMode.Solid:
                    attachedCollider.enabled = true;
                    attachedCollider.isTrigger = false;
                    break;
                case GraphCollisionMode.Intangible:
                    attachedCollider.enabled = false;
                    break;
                case GraphCollisionMode.DeathZone:
                    attachedCollider.enabled = true;
                    attachedCollider.isTrigger = true;
                    break;
            }
        }
    }

    void OnValidate() {
        if (!attachedCollider) {
            attachedCollider = GetComponent<Collider2D>();
        }
    }
}
