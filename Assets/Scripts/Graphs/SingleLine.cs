using System.Collections.Generic;
using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class SingleLine : MonoBehaviour, IGraphComponent {
    [Header("Parameters")]
    [SerializeField]
    Vector2Statistic statistic = default;
    [SerializeField]
    GraphCollisionMode m_collisionMode = default;
    public GraphCollisionMode collisionMode => m_collisionMode;

    [SerializeField, Range(0.0001f, 10)]
    float minStepX = 1;
    [SerializeField, Range(0.0001f, 10)]
    float minStepY = 1;
    [SerializeField, Range(0.0001f, 10)]
    float scaleX = 1;
    [SerializeField, Range(0.0001f, 10)]
    float scaleY = 1;

    [Header("References")]
    [SerializeField, Expandable]
    LineRenderer lineRenderer = default;
    [SerializeField, Expandable]
    EdgeCollider2D lineCollider = default;

    int currentIndex = 0;
    Stack<Vector2> values = new Stack<Vector2>();

    void Start() {
        Statistics.instance.onAddVector2 += AddVector2Listener;
        Statistics.instance.onRemoveVector2 += RemoveVector2Listener;

        lineRenderer.startColor = ColorSchemeManager.instance.GetColor(collisionMode);
        lineRenderer.endColor = ColorSchemeManager.instance.GetColor(collisionMode);
    }

    void AddVector2Listener(Vector2Statistic id, Vector2 value) {
        if (id == statistic) {
            value = RoundVertex(value);
            if (currentIndex == 0 || values.Peek() != value) {
                PushVertex(value);
            }
        }
    }
    void RemoveVector2Listener(Vector2Statistic id, Vector2 value) {
        value = RoundVertex(value);
        if (currentIndex != 0 && values.Peek() == value) {
            PopVertex();
        }
    }
    Vector2 RoundVertex(Vector2 value) {
        int x = Mathf.RoundToInt(value.x / minStepX);
        int y = Mathf.RoundToInt(value.y / minStepY);
        return new Vector2(x * minStepX, y * minStepY);
    }
    void PushVertex(Vector2 value) {
        values.Push(value);
        var scaledValue = new Vector2(value.x * scaleX, value.y * scaleY);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(currentIndex, scaledValue);
        lineCollider.points = lineCollider.points.Append(scaledValue).ToArray();
        currentIndex++;
    }
    void PopVertex() {
        values.Pop();
        lineRenderer.positionCount--;
        lineCollider.points = lineCollider.points.Take(lineCollider.points.Length - 1).ToArray();
        currentIndex--;
    }

    void OnValidate() {
        if (!lineRenderer) {
            lineRenderer = GetComponentInChildren<LineRenderer>();
        }
        if (!lineCollider) {
            lineCollider = GetComponentInChildren<EdgeCollider2D>();
        }
    }
}
