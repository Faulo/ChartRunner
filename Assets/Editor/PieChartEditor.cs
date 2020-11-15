using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PieChart))]
public class PieChartEditor : Editor {
    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        var myTarget = (PieChart)target;

        if (GUILayout.Button("Add Piece")) {
            myTarget.AddPiece();
        }
    }
}