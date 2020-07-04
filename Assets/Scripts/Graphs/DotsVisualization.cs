using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsVisualization : MonoBehaviour
{
    [Header("Parameters")]
    public Vector2[] curParameters = default;
    public Vector2Statistic vector2Statistic = default;
    public float stepSize = 1;
    int count = 0;
    float curStep = 0;

    [Header("References")]
    public GameObject dotPrefab = default;
    public List<GameObject> curDots = default;

    void Update()
    {
        var curStatistic = Statistics.instance.Get(vector2Statistic);


        foreach (var position in curStatistic) {
            if (position.x >= curStep) {

                Vector3 newPos = new Vector3(this.transform.position.x + position.x, this.transform.position.y + position.y, 0);
                //print(newPos);
                GameObject newDot = Instantiate(dotPrefab, newPos, Quaternion.identity);
                newDot.transform.SetParent(this.transform);
                curDots.Add(newDot);

                curStep += stepSize;
                count += 1;
            }
        }
    }
}
