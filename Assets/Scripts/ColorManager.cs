using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public SchemeColor color = default;

    public void Start() {
        ColorSchemeManager.instance.GetColor();
    }

    public void Colorize(Color newColor) {
        this.gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
}
