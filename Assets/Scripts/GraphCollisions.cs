using System.Collections.Generic;
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

    ISet<GraphCollider> triggeredColliders = new HashSet<GraphCollider>();

    void Start() {
        Enable();
    }

    void CollectCommands(ICollection<IUndoable> commands) {
        if (triggerTimer > 0) {
            triggerTimer -= Time.deltaTime;
        } else {
            triggerTimer = triggerDuration;
            foreach (var collider in triggeredColliders) {
                switch (collider.collisionMode) {
                    case GraphCollisionMode.Solid:
                        commands.Add(new EventCommand(gameObject, onSolidCollisionEnter));
                        break;
                    case GraphCollisionMode.Intangible:
                        commands.Add(new EventCommand(gameObject, onIntangibleCollisionEnter));
                        break;
                    case GraphCollisionMode.DeathZone:
                        commands.Add(new EventCommand(gameObject, onDeathZoneCollisionEnter));
                        break;
                }
            }
            triggeredColliders = new HashSet<GraphCollider>();
            //failsafe!
            if (transform.position.y < deathZoneY) {
                commands.Add(new EventCommand(gameObject, onDeathZoneCollisionEnter));
                commands.Add(new LambdaCommand(Disable, Enable));
            }
        }
    }
    void Enable() {
        Rewind.instance.onCollectCommands += CollectCommands;
        triggerTimer = 0;
    }
    void Disable() {
        Rewind.instance.onCollectCommands -= CollectCommands;
        triggerTimer = float.PositiveInfinity;
    }

    void CollisionEnter(GameObject other) {
        if (other.TryGetComponent<GraphCollider>(out var collider)) {
            if (!triggeredColliders.Contains(collider)) {
                triggeredColliders.Add(collider);
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
