using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSchemes", menuName = "ScriptableObjects/ColorSchemes", order = 1)]
public class ColorScheme : ScriptableObject
{
    public Color mainColor = default;
    public Color backgroundColor = default;
    public Color foregroundColor = default;
    public Color highlightColor = default;
    public Color negativeHighlightColor = default;
    public Color positiveHighlightColor = default;

    public void ApplyColorScheme(ColorManager curManager) {
        //Debug.Log("Lol");
        SchemeColor curColor = curManager.color;
        switch (curColor) {
                   case SchemeColor.mainColor:
                        curManager.Colorize(mainColor);
                        break;
                    case SchemeColor.foregroundColor:
                        curManager.Colorize(foregroundColor);
                        break;
                   case SchemeColor.backgroundColor:
                        curManager.Colorize(backgroundColor);
                        break;
                    case SchemeColor.highlightColor:
                        curManager.Colorize(highlightColor);
                        break;
                    case SchemeColor.negativeHighlightColor:
                        curManager.Colorize(negativeHighlightColor);
                        break;
                    case SchemeColor.positiveHighlightColor:
                        curManager.Colorize(positiveHighlightColor);
                        break;
                    default:
                        curManager.Colorize(mainColor);
                        break;
                }
        }
    }
