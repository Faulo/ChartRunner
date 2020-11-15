using System.Collections.Generic;
using UnityEngine;

public class BarChart : MonoBehaviour {
    [Header("Parameters")]
    public float maxYSize = 2;
    public float xSize = 0.1f;

    [Header("References")]
    public GameObject barPartPrefab = default;
    public List<GameObject> barParts = default;
    public List<float> barValues = default;
    [SerializeField] float maxValue = 0;
    [SerializeField] float onePercent = 0;
    [SerializeField] float curHeight = 0;

    void Start() {
        foreach (var bar in gameObject.GetComponentsInChildren<Transform>()) {
            if (bar.gameObject.GetComponent<BarPartVisualization>()) {
                barParts.Add(bar.gameObject);
            }
        }


        foreach (var barPart in barParts) {
            barValues.Add(0);
        }
    }

    public void Update() {

        CalculateGraphParts();
    }

    public void AddBarPart() {
        var newBarPart = Instantiate(barPartPrefab, transform.position, Quaternion.identity);
        newBarPart.transform.SetParent(transform);
        newBarPart.name = "BarPart" + barParts.Count;

        barParts.Add(newBarPart);
    }

    public void CalculateGraphParts() {
        //Actualize values
        int counter = 0;
        foreach (var barPart in barParts) {
            barValues[counter] = Statistics.instance.Get(barPart.GetComponent<BarPartVisualization>().floatStatistic);
            counter += 1;
        }

        //add values
        maxValue = 0;
        foreach (float value in barValues) {
            maxValue += value;
        }
        //calculate percent
        onePercent = maxValue / 100;


        counter = 0;
        curHeight = 0;
        foreach (var barPart in barParts) {
            float ySize = barValues[counter] / onePercent * (maxYSize / 100);
            var newSize = new Vector3(xSize, ySize, 1);
            barPart.transform.localScale = newSize;

            if (counter > 0) {
                barPart.transform.position = new Vector3(transform.position.x, barParts[counter - 1].GetComponent<BarPartVisualization>().topPivot.position.y, 0);
            }
            curHeight += barPart.transform.localScale.y;


            counter += 1;
        }
    }
}
