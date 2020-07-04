using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BarGraph))]
public class BarGraphEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        BarGraph myTarget = (BarGraph)target;

        if (GUILayout.Button("Add Bar")) {
            myTarget.AddBar();
        }
    }
}