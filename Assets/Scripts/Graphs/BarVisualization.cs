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
    private void Start() {
        yPos = this.transform.position.y;
    }

    void Update() {
        value = Statistics.instance.Get(statistic);

        // magic number 0.256 pro 0.1 Verschiebung nach oben
        this.transform.localScale = new Vector3(0.1f, value / 10f, 0.1f);

        
        this.transform.position = new Vector3(this.transform.position.x, yPos + value * yOffset, 0);
    }
}
