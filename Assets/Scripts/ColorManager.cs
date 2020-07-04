using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;

public class ColorManager : MonoBehaviour {
    [SerializeField]
    SchemeColor schemeColor = default;
    [SerializeField, Expandable]
    SpriteRenderer spriteRenderer = default;
    [SerializeField, Expandable]
    LineRenderer lineRenderer = default;
    [SerializeField, Expandable]
    ParticleSystem particles = default;
    [SerializeField, Expandable]
    TextMeshProUGUI textMesh = default;

    public void Start() {
        UpdateColors();
    }

    void OnValidate() {
        if (!spriteRenderer) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (!lineRenderer) {
            lineRenderer = GetComponent<LineRenderer>();
        }
        if (!particles) {
            particles = GetComponent<ParticleSystem>();
        }
        if (!textMesh) {
            textMesh = GetComponent<TextMeshProUGUI>();
        }
    }

    void UpdateColors() {
        var color = ColorSchemeManager.instance.GetColor(schemeColor);
        if (spriteRenderer) {
            spriteRenderer.color = color;
        }
        if (lineRenderer) {
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
        }
        if (particles) {
            var main = particles.main;
            main.startColor = color;
        }
        if (textMesh) {
            textMesh.color = color;
        }
    }
}
