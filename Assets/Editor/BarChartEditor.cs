using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BarChart))]
public class BarChartEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        var myTarget = (BarChart)target;

        if (GUILayout.Button("Add Bar Part")) {
            myTarget.AddBarPart();
        }
    }
}