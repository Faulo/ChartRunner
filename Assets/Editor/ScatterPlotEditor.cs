using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScatterPlot))]
public class ScatterPlotEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        var myTarget = (ScatterPlot)target;

        if (GUILayout.Button("Add Dots")) {
            myTarget.AddDots();
        }
    }
}