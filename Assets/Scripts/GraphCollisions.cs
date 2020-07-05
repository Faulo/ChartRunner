using UnityEngine;
using UnityEngine.Serialization;

public class GraphCollisions : MonoBehaviour {
    [SerializeField]
    GameObjectEvent onSolidCollisionEnter = default;
    [SerializeField]
    GameObjectEvent onIntangibleCollisionEnter = default;
    [SerializeField, FormerlySerializedAs("onDeahtZoneCollisionEnter")]
    GameObjectEvent onDeathZoneCollisionEnter = default;
    [SerializeField, Range(0, 10), Tooltip("How many seconds to wait between each trigger")]
    float triggerDuration = 0;
    [SerializeField, Range(-100, 0)]
    float deathZoneY = -1;

    float triggerTimer;
    bool canTrigger => triggerTimer <= 0;
    void CollisionEnter(GameObject other) {
        if (!canTrigger) {
            return;
        }
        if (other.TryGetComponent<GraphCollider>(out var collider)) {
            triggerTimer = triggerDuration;
            switch (collider.collisionMode) {
                case GraphCollisionMode.Solid:
                    onSolidCollisionEnter.Invoke(gameObject);
                    break;
                case GraphCollisionMode.Intangible:
                    onIntangibleCollisionEnter.Invoke(gameObject);
                    break;
                case GraphCollisionMode.DeathZone:
                    onDeathZoneCollisionEnter.Invoke(gameObject);
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

    void FixedUpdate() {
        if (triggerTimer > 0) {
            triggerTimer -= Time.deltaTime;
        }
        //failsafe!
        if (transform.position.y < deathZoneY) {
            onDeathZoneCollisionEnter.Invoke(gameObject);
            enabled = false;
        }
    }
}
