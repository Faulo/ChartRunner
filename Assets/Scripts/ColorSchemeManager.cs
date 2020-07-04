using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSchemeManager : MonoBehaviour
{
    public ColorSchemes[] colorSchemes = default;

    public void Start() {
        int n = Random.Range(0, colorSchemes.Length - 1);

        colorSchemes[n].ApplyColorScheme();
    }
}
