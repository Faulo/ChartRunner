using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSchemeManager : MonoBehaviour
{
    public ColorScheme[] colorSchemes = default;

    public ColorScheme currentScheme = default;

    public static ColorSchemeManager instance = default;

    public void Awake() {
        instance = this;

        int n = Random.Range(0, colorSchemes.Length);
        currentScheme = colorSchemes[n];
    }

    public void GetColor() {
        currentScheme.ApplyColorScheme();
    }

}
