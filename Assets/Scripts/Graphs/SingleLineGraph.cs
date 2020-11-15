using System.Collections.Generic;
using UnityEngine;

public class SingleLineGraph : MonoBehaviour {
    public Transform startPos = default;

    public List<GameObject> lines = default;
    public GameObject linePrefab = default;

    public void AddLine() {
        var newLine = Instantiate(linePrefab, startPos.position, Quaternion.identity);
        newLine.transform.SetParent(transform);
        newLine.name = "Line" + lines.Count;
        lines.Add(newLine);
    }
}
