using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SingleBarGraph))]
public class SingleBarGraphEditor : Editor {
    new SingleBarGraph target => base.target as SingleBarGraph;
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        if (GUILayout.Button("Add Bar")) {
            PrefabUtility.InstantiatePrefab(target.barPrefab, target.transform);
            target.OnValidate();
        }
    }
}