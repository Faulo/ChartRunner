using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BarChart))]
public class BarChartEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        BarChart myTarget = (BarChart)target;

        if (GUILayout.Button("Add Bar Part")) {
            myTarget.AddBarPart();
        }
    }
}