using Slothsoft.UnityExtensions;
using UnityEngine;

public class ActivateOnStart : MonoBehaviour {
    [SerializeField, Expandable]
    SpriteRenderer spriteRenderer = default;
    void OnValidate() {
        if (!spriteRenderer) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    void Start() {
        if (spriteRenderer) {
            float n = Random.Range(0f, 1f);
            //Debug.Log(n);
            if (n > 0.5f) {
                spriteRenderer.enabled = true;
            }
        }
    }
}
