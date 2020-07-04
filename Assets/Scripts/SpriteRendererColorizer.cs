using Slothsoft.UnityExtensions;
using UnityEngine;

public class SpriteRendererColorizer : MonoBehaviour {
    [SerializeField]
    SchemeColor color = default;
    [SerializeField, Expandable]
    SpriteRenderer attachedRenderer = default;

    public void Start() {
        attachedRenderer.color = ColorSchemeManager.instance.GetColor(color);
    }

    void OnValidate() {
        if (!attachedRenderer) {
            attachedRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
