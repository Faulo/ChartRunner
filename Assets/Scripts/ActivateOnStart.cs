using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slothsoft.UnityExtensions;

public class ActivateOnStart : MonoBehaviour
{
    [SerializeField, Expandable]
    SpriteRenderer spriteRenderer = default;
    void OnValidate() {
        if (!spriteRenderer) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    private void Start() {
        if (spriteRenderer) {
            float n = Random.Range(0f, 1f);
            Debug.Log(n);
            if(n > 0.5f) {
                spriteRenderer.enabled = true;
            }
        }
    }
}
