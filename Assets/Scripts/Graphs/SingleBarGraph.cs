using Slothsoft.UnityExtensions;
using UnityEngine;

public class SingleBarGraph : MonoBehaviour {
    [Header("Parameters")]
    [SerializeField, Range(0, 10), Tooltip("height per unit of each bar")]
    float barScale = 1;
    [SerializeField, Range(0, 10), Tooltip("width of each bar")]
    float barWidth = 1;
    [SerializeField, Range(0, 10), Tooltip("distance between individual bars")]
    float barDistance = 1;

    [Header("References")]
    [SerializeField, Expandable]
    SingleBar[] bars = default;
    [SerializeField, Expandable]
    public SingleBar barPrefab = default;

    void Start() {
        UpdateBars();
    }
    public void OnValidate() {
        UpdateBars();
    }
    void UpdateBars() {
        bars = GetComponentsInChildren<SingleBar>();
        for (int i = 0; i < bars.Length; i++) {
            bars[i].gameObject.name = $"Bar_{i}";
            bars[i].scale = barScale;
            bars[i].width = barWidth;
            bars[i].transform.localPosition = Vector3.right * i * (barDistance + barWidth);
            bars[i].OnValidate();
        }
    }

    public void AddBar() {
        Instantiate(barPrefab, transform);
        OnValidate();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}
