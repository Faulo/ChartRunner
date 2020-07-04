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
        if(this.gameObject.GetComponent<LineRenderer>()) {
            this.gameObject.GetComponent<LineRenderer>().startColor = newColor;
            this.gameObject.GetComponent<LineRenderer>().endColor = newColor;
        } else {
            this.gameObject.GetComponent<SpriteRenderer>().color = newColor;
        }
    }
}
