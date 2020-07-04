using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;

public class GraphAxis : MonoBehaviour {
    [SerializeField, Range(0, 100)]
    public float length = 1;
    [SerializeField]
    public string[] labelNames = new string[0];
    [SerializeField]
    public float[] labelPositions = new float[0];
    [SerializeField, Expandable]
    TextMeshProUGUI[] labels = new TextMeshProUGUI[0];
    [SerializeField, Expandable]
    TextMeshProUGUI labelPrefab = default;

    void Start() {
        UpdateAxis();

        if (labelPrefab && labelNames.Length == labelPositions.Length) {
            labels = new TextMeshProUGUI[labelNames.Length];
            for (int i = 0; i < labels.Length; i++) {
                // @TODO: fix positioning
                /*
                var worldPosition = transform.position + (Vector3.right * labelPositions[i]);
                labels[i] = Instantiate(labelPrefab);
                labels[i].text = labelNames[i];
                var canvasPosition = Camera.main.WorldToScreenPoint(worldPosition);
                labels[i].rectTransform.anchoredPosition = canvasPosition;
                //*/
            }
        }
    }

    public void OnValidate() {
        UpdateAxis();
    }

    void UpdateAxis() {
        transform.localScale = new Vector3(length, 1, 1);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * length);
    }
}
