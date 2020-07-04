using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSchemes", menuName = "ScriptableObjects/ColorSchemes", order = 1)]
public class ColorSchemes : ScriptableObject
{
    public Color mainColor = default;
    public Color backgroundColor = default;
    public Color foregroundColor = default;
    public Color highlightColor = default;
    public Color negativeHighlightColor = default;
    public Color positiveHighlightColor = default;

    public void ApplyColorScheme() {
        ColorManager[] colorManagers = FindObjectsOfType<ColorManager>();
        foreach(ColorManager color in colorManagers) {
            switch (color.color) {
                case SchemeColor.mainColor:
                    color.Colorize(mainColor);
                    break;
                case SchemeColor.foregroundColor:
                    color.Colorize(foregroundColor);
                    break;
                case SchemeColor.backgroundColor:
                    color.Colorize(backgroundColor);
                    break;
                case SchemeColor.highlightColor:
                    color.Colorize(highlightColor);
                    break;
                case SchemeColor.negativeHighlightColor:
                    color.Colorize(negativeHighlightColor);
                    break;
                case SchemeColor.positiveHighlightColor:
                    color.Colorize(positiveHighlightColor);
                    break;
                default:
                    color.Colorize(mainColor);
                    break;
            }
        }
    }
}
