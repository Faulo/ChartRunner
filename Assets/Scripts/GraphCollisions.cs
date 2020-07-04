using UnityEngine;

public class GraphCollisions : MonoBehaviour {
    [SerializeField]
    GameObjectEvent onSolidCollisionEnter = default;
    [SerializeField]
    GameObjectEvent onIntangibleCollisionEnter = default;
    [SerializeField]
    GameObjectEvent onDeahtZoneCollisionEnter = default;

    void CollisionEnter(GameObject other) {
        if (other.TryGetComponent<GraphCollider>(out var collider)) {
            switch (collider.collisionMode) {
                case GraphCollisionMode.Solid:
                    onSolidCollisionEnter.Invoke(gameObject);
                    break;
                case GraphCollisionMode.Intangible:
                    onIntangibleCollisionEnter.Invoke(gameObject);
                    break;
                case GraphCollisionMode.DeathZone:
                    onDeahtZoneCollisionEnter.Invoke(gameObject);
                    break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        CollisionEnter(collision.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collider) {
        CollisionEnter(collider.gameObject);
    }
}
