using UnityEngine;

public class PieGraph : MonoBehaviour {
    [Header("Parameters")]
    [Tooltip("True - Floats / False - Dicts")]
    public bool floatStatistics = true;
    [Range(0.1f, 1f)]
    public float scaleFactor = 1;
    public float value = 0;


    public FloatStatistic floatStatistic = default;
    public DictionaryStatistic dictionaryStatistic = default;

    [Header("References")]
    public GameObject pie = default;

    void Update() {
        if (floatStatistics) {
            value = Statistics.instance.Get(floatStatistic);
        } else {
            foreach (var (name, value) in Statistics.instance.Get(dictionaryStatistic)) {
                this.value = value;
                break;
            }
        }
        var newScale = new Vector3(value, value, value) * scaleFactor;
        pie.transform.localScale = newScale;
    }
}
