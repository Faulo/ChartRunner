using UnityEngine;

public class BarPartVisualization : MonoBehaviour {
    public FloatStatistic floatStatistic = default;
    public Transform topPivot = default;

    public Transform midPivot = default;
    public Vector3 offset = new Vector3(0f, 1f, 0);
    public GameObject textPrefab = default;

    public void Start() {
        var header = Instantiate(textPrefab, transform.position, Quaternion.identity);
        header.GetComponentInChildren<GraphHeader>().label = floatStatistic.Translate();
        textPrefab = header;
    }

    void Update() {
        //WERDEN NOCH NICHT AN DEM RICHTIGEN OBJEKT AUSGEREICHTET
        textPrefab.transform.position = midPivot.position + offset;
    }
}
