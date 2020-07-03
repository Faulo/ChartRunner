using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BarGraph))]
public class LevelScriptEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        BarGraph myTarget = (BarGraph)target;

        if (GUILayout.Button("Add Graph")) {
            myTarget.AddGraph();
        }
    }
}