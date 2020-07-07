using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;

public class GraphHeader : MonoBehaviour {
    [SerializeField]
    public string label = "";
    [SerializeField, Expandable]
    TextMeshProUGUI textMesh = default;

    void Start() {
        if (textMesh) {
            textMesh.text = label;
        }
    }

    void OnValidate() {
        if (!textMesh) {
            textMesh = GetComponent<TextMeshProUGUI>();
        }
    }
}
