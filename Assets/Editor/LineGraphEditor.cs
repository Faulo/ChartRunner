using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SingleLineGraph))]
public class LineGraphEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        var myTarget = (SingleLineGraph)target;

        if (GUILayout.Button("Add Line")) {
            myTarget.AddLine();
        }
    }
}