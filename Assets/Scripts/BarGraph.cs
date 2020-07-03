using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGraph : MonoBehaviour
{
    public List<Bar> bars = default;
    public GameObject barPrefab = default;

    public void AddGraph() {
        Bar newBarParamters = new Bar(1, "strength");
        bars.Add(newBarParamters);


        Vector2 newPos = new Vector2(bars.Count, 0);
        GameObject newBar = Instantiate(barPrefab, newPos, Quaternion.identity);
        newBar.transform.SetParent(this.transform);
        newBar.name = "Bar" + bars.Count;

        newBar.GetComponent<BarVisualization>().bar = newBarParamters;
    }
}
