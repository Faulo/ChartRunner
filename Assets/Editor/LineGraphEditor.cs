using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LineGraph))]
public class LineGraphEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        LineGraph myTarget = (LineGraph)target;

        if (GUILayout.Button("Add Line")) {
            myTarget.AddLine();
        }
    }
}