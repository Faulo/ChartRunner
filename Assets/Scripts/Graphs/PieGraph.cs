using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieGraph : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Ture - Floats / False - Dicts")]
    public bool floatStatistics = true;
    [Range(0.1f, 1f)]
    public float scaleFactor = 1;
    public float value = 0;


    public FloatStatistic floatStatistic = default;
    public DictionaryStatistic dictionaryStatistic = default;

    [Header("References")]
    public GameObject pie = default;

    void Update()
    {
        if (true) {
            value = Statistics.instance.Get(floatStatistic);
        } else {
            var curDict = Statistics.instance.Get(dictionaryStatistic);
            foreach(var keyValuePair in curDict) {
                value = keyValuePair.Item2;
            }
        }

        Vector3 newScale = new Vector3(value, value, value) * scaleFactor;
        pie.transform.localScale = newScale;
    }
}
