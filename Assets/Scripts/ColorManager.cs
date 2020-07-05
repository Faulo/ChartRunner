using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour {
    [SerializeField, FormerlySerializedAs("color")]
    SchemeColor schemeColor = default;
    [SerializeField, Range(0, 1)]
    float transparence = 1;
    [SerializeField, Expandable]
    SpriteRenderer spriteRenderer = default;
    [SerializeField, Expandable]
    LineRenderer lineRenderer = default;
    [SerializeField, Expandable]
    ParticleSystem particles = default;
    [SerializeField, Expandable]
    TextMeshProUGUI textMesh = default;
    [SerializeField, Expandable]
    Image image = default;

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
        if (!image) {
            image = GetComponent<Image>();
        }
    }

    void UpdateColors() {
        var color = ColorSchemeManager.instance.GetColor(schemeColor);
        if (spriteRenderer) {
            spriteRenderer.color = new Color(color.r, color.g, color.b, transparence);
        }
        if (lineRenderer) {
            lineRenderer.startColor = new Color(color.r, color.g, color.b, transparence);
            lineRenderer.endColor = new Color(color.r, color.g, color.b, transparence);
        }
        if (particles) {
            var main = particles.main;
            main.startColor = new Color(color.r, color.g, color.b, transparence);
        }
        if (textMesh) {
            textMesh.color = new Color(color.r, color.g, color.b, transparence);
        }
        if (image) {
            image.color = new Color(color.r, color.g, color.b, transparence);
        }
    }
}
