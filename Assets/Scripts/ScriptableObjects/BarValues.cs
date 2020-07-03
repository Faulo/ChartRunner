using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BarValues", menuName = "ScriptableObjects/BarValues", order = 1)]
public class BarValues : ScriptableObject
{
    public float value = 0;
    public FloatStatistic statistic = default;
}
