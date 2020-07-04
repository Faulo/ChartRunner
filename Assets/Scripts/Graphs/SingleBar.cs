using Slothsoft.UnityExtensions;
using UnityEngine;

public class SingleBar : MonoBehaviour, IGraphComponent {
    [Header("Parameters")]
    [SerializeField]
    public FloatStatistic statistic = default;
    [SerializeField]
    GraphCollisionMode m_collisionMode = default;
    public GraphCollisionMode collisionMode => m_collisionMode;

    [SerializeField, Range(0, 10)]
    public float scale = 1;
    [SerializeField, Range(0, 10)]
    public float width = 1;
    [SerializeField, Range(0, 10)]
    float scalingDuration = 1;


    [Header("References")]
    [SerializeField, Expandable]
    SpriteRenderer spriteRenderer = default;

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
        spriteRenderer.color = ColorSchemeManager.instance.GetColor(collisionMode);
    }
    public void OnValidate() {
        floatValue = 1;
        UpdateTransformNow();
        if (!spriteRenderer) {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }
    void UpdateTransformNow() {
        transform.localScale = targetScale;
    }
    void UpdateTransformSmooth() {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref scalingVelocity, scalingDuration);
    }
}
