using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarPartVisualization : MonoBehaviour
{
    public FloatStatistic floatStatistic = default;
    public Transform topPivot = default;

    public Transform midPivot = default;
    public Vector3 offset = new Vector3(0f, 1f, 0);
    public GameObject textPrefab = default;

    public void Start() {
        GameObject header = Instantiate(textPrefab, this.transform.position, Quaternion.identity);
        header.GetComponentInChildren<GraphHeader>().ApplyHeader(floatStatistic.ToString());
        textPrefab = header;
    }

    private void Update() {
        //WERDEN NOCH NICHT AN DEM RICHTIGEN OBJEKT AUSGEREICHTET
        textPrefab.transform.position = midPivot.position + offset;
    }
}
