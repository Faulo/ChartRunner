using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarVisualization : MonoBehaviour
{
    [Header("Parameters")]
    public float value = 0;
    public FloatStatistic statistic = default;

    [Tooltip("Y Wert steht fuer parameter per Value")]
    public Vector3 size = new Vector3(1f, 1f, 1f);

    Transform parent = default;
    private void Start() {
        parent = GetComponentInParent<Transform>();
    }

    void Update() {
        value = Statistics.instance.Get(statistic);

        // magic number 0.256 pro 0.1 Verschiebung nach oben
        this.transform.localScale = new Vector3(size.x, value * size.y, size.z);
    }
}
