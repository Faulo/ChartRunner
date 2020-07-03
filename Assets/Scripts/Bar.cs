using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Bar
{
    public float value = 0;
    public string parameter = "";

    public Bar(float newValue, string newParameter) {
        value = newValue;
        parameter = newParameter;
    }
}
