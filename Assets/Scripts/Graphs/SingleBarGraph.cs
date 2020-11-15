using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class SingleBarGraph : MonoBehaviour {
    [Header("Parameters")]
    [SerializeField, Range(0, 10), Tooltip("Height per unit of each bar")]
    float barScale = 1;
    [SerializeField, Range(0, 10), Tooltip("Width of each bar")]
    float barWidth = 1;
    [SerializeField, Range(0, 10), Tooltip("Distance between individual bars")]
    float barDistance = 1;
    [SerializeField, Range(0, 100), Tooltip("Length of the ordinate, if drawn")]
    float ordinateHeight = 1;

    [Header("References")]
    [SerializeField, Expandable]
    SingleBar[] bars = default;
    [SerializeField, Expandable]
    public SingleBar barPrefab = default;
    [SerializeField, Expandable]
    GraphAxis abscissa = default;
    [SerializeField, Expandable]
    GraphAxis ordinate = default;

    void Start() {
        UpdateBars();
        UpdateAxes();
    }
    public void OnValidate() {
        UpdateBars();
        UpdateAxes();
    }
    void UpdateBars() {
        bars = GetComponentsInChildren<SingleBar>();
        for (int i = 0; i < bars.Length; i++) {
            bars[i].gameObject.name = $"Bar_{i}";
            bars[i].scale = barScale;
            bars[i].width = barWidth;
            bars[i].transform.localPosition = (Vector3.right * i * (barDistance + barWidth)) + new Vector3(barDistance / 2, 0, 0);
            bars[i].OnValidate();
        }
    }
    void UpdateAxes() {
        if (abscissa) {
            abscissa.length = (bars.Length * barWidth) + ((bars.Length - 1) * barDistance) + barDistance;
            abscissa.labelNames = bars.Select(bar => bar.statistic.Translate()).ToArray();
            abscissa.labelPositions = bars.Select(bar => bar.transform.localPosition.x + (barWidth / 2)).ToArray();
            abscissa.OnValidate();
        }
        if (ordinate) {
            ordinate.length = ordinateHeight * barScale;
            ordinate.OnValidate();
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
