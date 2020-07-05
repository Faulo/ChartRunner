using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SingleLineGraph))]
public class LineGraphEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        SingleLineGraph myTarget = (SingleLineGraph)target;

        if (GUILayout.Button("Add Line")) {
            myTarget.AddLine();
        }
    }
}