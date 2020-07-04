using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGraph : MonoBehaviour
{
    [Header("Parameters")]
    public float xOffset = 1;

    [Header("References")]
    public List<GameObject> bars = default;
    public GameObject barPrefab = default;

    public void AddBar() {
        BarValues newBarValues = new BarValues();

        Vector2 newPos = new Vector2(bars.Count * xOffset, 0);
        GameObject newBar = Instantiate(barPrefab, newPos, Quaternion.identity);
        newBar.transform.SetParent(this.transform);
        newBar.name = "Bar" + bars.Count;
        bars.Add(newBar);
    }
}
