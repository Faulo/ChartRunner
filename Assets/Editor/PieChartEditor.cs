using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PieChart))]
public class PieChartEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        PieChart myTarget = (PieChart)target;

        if (GUILayout.Button("Add Piece")) {
            myTarget.AddPiece();
        }
    }
}