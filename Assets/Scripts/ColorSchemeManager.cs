using System;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class ColorSchemeManager : MonoBehaviour {
    public static ColorSchemeManager instance = default;

    [SerializeField, Expandable]
    ColorScheme[] colorSchemes = default;
    [SerializeField, Expandable]
    ColorScheme currentScheme = default;


    public void Awake() {
        instance = this;

        currentScheme = colorSchemes.RandomElement();
    }

    public Color GetColor(SchemeColor color) {
        switch (color) {
            case SchemeColor.mainColor:
                return currentScheme.mainColor;
            case SchemeColor.effectColor:
                return currentScheme.effectColor;
            case SchemeColor.backgroundColor:
                return currentScheme.backgroundColor;
            case SchemeColor.highlightColor:
                return currentScheme.highlightColor;
            case SchemeColor.negativeHighlightColor:
                return currentScheme.negativeHighlightColor;
            case SchemeColor.positiveHighlightColor:
                return currentScheme.positiveHighlightColor;
            default:
                throw new NotImplementedException(color.ToString());
        }
    }

    public Color GetColor(GraphCollisionMode collisionMode) {
        switch (collisionMode) {
            case GraphCollisionMode.Solid:
                return currentScheme.highlightColor;
            case GraphCollisionMode.Intangible:
                return currentScheme.positiveHighlightColor;
            case GraphCollisionMode.DeathZone:
                return currentScheme.negativeHighlightColor;
            default:
                throw new NotImplementedException(collisionMode.ToString());
        }
    }

}
