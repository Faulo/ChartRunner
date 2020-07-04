using UnityEngine;

public class SingleBar : MonoBehaviour {
    [Header("Parameters")]
    [SerializeField]
    public FloatStatistic statistic = default;

    [SerializeField, Range(0, 10)]
    public float scale = 1;
    [SerializeField, Range(0, 10)]
    public float width = 1;
    [SerializeField, Range(0, 10)]
    float scalingDuration = 1;

    public float floatValue { get; private set; }
    Vector3 targetScale => new Vector3(width, floatValue * scale, 1);
    Vector3 scalingVelocity;

    void Update() {
        UpdateTransformSmooth();
    }
    void FixedUpdate() {
        floatValue = Statistics.instance.Get(statistic);
    }
    void Start() {
        floatValue = 0;
        UpdateTransformNow();
    }
    public void OnValidate() {
        floatValue = 1;
        UpdateTransformNow();
    }
    void UpdateTransformNow() {
        transform.localScale = targetScale;
    }
    void UpdateTransformSmooth() {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref scalingVelocity, scalingDuration);
    }
}
