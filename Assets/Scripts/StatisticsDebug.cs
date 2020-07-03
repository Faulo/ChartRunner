using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;

public class StatisticsDebug : MonoBehaviour {
    [SerializeField, Expandable]
    TextMeshProUGUI textMesh = default;

    void Update() {
        textMesh.text = Statistics.instance.statusText;
    }

    void OnValidate() {
        if (!textMesh) {
            textMesh = GetComponentInParent<TextMeshProUGUI>();
        }
    }
}
