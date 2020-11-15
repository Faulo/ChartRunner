using System.Collections.Generic;
using UnityEngine;

public class DotsVisualization : MonoBehaviour {
    [Header("Parameters")]
    public Vector2[] curParameters = default;
    public Vector2Statistic vector2Statistic = default;
    public float stepSize = 1;
    int count = 0;
    float curStep = 0;

    //latest values for rewind
    float lastValue = 0;
    float curLastValue = 0;

    [Header("References")]
    public GameObject dotPrefab = default;
    public List<GameObject> curDots = default;

    void Update() {
        var curStatistic = Statistics.instance.Get(vector2Statistic);
        foreach (var position in curStatistic) {
            curLastValue = position.x;
        }

        DeleteDotsOnRewind();

        foreach (var position in curStatistic) {
            if (position.x >= curStep) {

                //print(newPos);
                var newDot = Instantiate(dotPrefab, transform.position, Quaternion.identity);
                newDot.transform.SetParent(transform);
                var newPos = new Vector3(newDot.transform.position.x + position.x, newDot.transform.position.y + position.y, 0);
                newDot.transform.position = newPos;
                curDots.Add(newDot);

                lastValue = position.x;
                curStep += stepSize;
                count += 1;
            }
        }
    }

    void DeleteDotsOnRewind() {
        if (curLastValue < lastValue) {
            var deleteDots = new List<GameObject>();
            foreach (var dot in curDots) {
                if (dot.transform.position.x > curLastValue) {
                    deleteDots.Add(dot);
                    curStep -= stepSize;
                }
            }

            foreach (var dot in deleteDots) {
                curDots.Remove(dot);
                GameObject.Destroy(dot);
            }
            deleteDots.Clear();
        }
    }
}
