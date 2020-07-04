using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorManager : MonoBehaviour
{
    public SchemeColor color = default;

    public void Start() {
        ColorSchemeManager.instance.GetColor(this);
    }

    public void Colorize(Color newColor) {
        if(this.gameObject.GetComponent<LineRenderer>()) {
            this.gameObject.GetComponent<LineRenderer>().startColor = newColor;
            this.gameObject.GetComponent<LineRenderer>().endColor = newColor;
        } 
        else if (this.gameObject.GetComponent<TextMeshProUGUI>()){
            this.gameObject.GetComponent<TextMeshProUGUI>().color = newColor;
        }
        else if (this.gameObject.GetComponent<ParticleSystem>()) {
            ParticleSystem.MainModule particleSystem = this.gameObject.GetComponent<ParticleSystem>().main;
            particleSystem.startColor = newColor;
        } else {
            this.gameObject.GetComponent<SpriteRenderer>().color = newColor;
        }
    }
}
