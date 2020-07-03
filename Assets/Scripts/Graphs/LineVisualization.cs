using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisualization : MonoBehaviour
{
    [Header("Parameters")]
    public Vector2[] curParameters = default;
    public Vector2Statistic vector2Statistic = default;
    public float stepSize = 1;
    int count = 0;
    float curStep = 0;

    [Header("References")]
    public LineRenderer lineRenderer = default;

    void Update() {
        var curStatistic = Statistics.instance.Get(vector2Statistic);
        

        foreach (var position in curStatistic) {
            lineRenderer.positionCount = count + 1;
            if (lineRenderer.positionCount <= count) {
                //DER ENTSTEHENDE VEKTOR FUNKTIONIERT NICHT
                print(position.x + " " + position.y);
                lineRenderer.SetPosition(count, new Vector3(position.x, position.y, 0));
            }
                
            count += 1;
        }
        
    }
}
