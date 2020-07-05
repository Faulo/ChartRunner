using UnityEngine;

[CreateAssetMenu(fileName = "ColorSchemes", menuName = "ScriptableObjects/ColorSchemes", order = 1)]
public class ColorScheme : ScriptableObject {
    public Color mainColor = default;
    public Color backgroundColor = default;
    public Color effectColor = default;
    public Color highlightColor = default;
    public Color negativeHighlightColor = default;
    public Color positiveHighlightColor = default;
}
