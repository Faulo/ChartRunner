﻿using System.Collections.Generic;
using UnityEngine;

public class ScatterPlot : MonoBehaviour {
    public Transform startPos = default;

    public List<GameObject> dots = default;
    public GameObject dotsPrefab = default;

    public void AddDots() {
        var newLine = Instantiate(dotsPrefab, startPos.position, Quaternion.identity);
        newLine.transform.SetParent(transform);
        newLine.name = "Dots" + dots.Count;
        dots.Add(newLine);
    }
}
