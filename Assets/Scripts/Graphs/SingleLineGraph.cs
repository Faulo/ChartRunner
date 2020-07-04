using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLineGraph : MonoBehaviour
{
    public Transform startPos = default;

    public List<GameObject> lines = default;
    public GameObject linePrefab = default;

    public void AddLine() {
        GameObject newLine = Instantiate(linePrefab, startPos.position, Quaternion.identity);
        newLine.transform.SetParent(this.transform);
        newLine.name = "Line" + lines.Count;
        lines.Add(newLine);
    }
}
