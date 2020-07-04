using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSchemes", menuName = "ScriptableObjects/ColorSchemes", order = 1)]
public class ColorSchemes : ScriptableObject
{
    public Material mainColor = default;
    public Material backgroundColor = default;
    public Material foregroundColor = default;
    public Material highlightColor = default;

    public void ApplyColorScheme() {

    }
}
