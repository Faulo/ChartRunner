using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarVisualization : MonoBehaviour
{
    [Header("Parameters")]
    public float value = 0;
    public FloatStatistic statistic = default;

    float yOffset = 0.256f;
    float yPos = 0f;

    Transform parent = default;
    private void Start() {
        parent = GetComponentInParent<Transform>();
        yPos = parent.transform.position.y;
    }

    void Update() {
        value = Statistics.instance.Get(statistic);

        // magic number 0.256 pro 0.1 Verschiebung nach oben
        this.transform.localScale = new Vector3(1f, value, 1f);

        
        this.transform.position = new Vector3(this.transform.position.x, yPos, 0);
    }
}
