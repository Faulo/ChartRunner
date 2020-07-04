﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterPlot : MonoBehaviour
{
    public Transform startPos = default;

    public List<GameObject> dots = default;
    public GameObject dotsPrefab = default;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDots() {
        GameObject newLine = Instantiate(dotsPrefab, startPos.position, Quaternion.identity);
        newLine.transform.SetParent(this.transform);
        newLine.name = "Dots" + dots.Count;
        dots.Add(newLine);
    }
}
