using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ScatterPlot))]
public class ScatterPlotEditor  : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        ScatterPlot myTarget = (ScatterPlot)target;

        if (GUILayout.Button("Add Dots")) {
            myTarget.AddDots();
        }
    }
}