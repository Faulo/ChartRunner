using UnityEngine;

public class Vector2StatisticCommand : IUndoable {
    Vector2Statistic id;
    Vector2 value;

    public Vector2StatisticCommand(Vector2Statistic id, Vector2 value) {
        this.id = id;
        this.value = value;
    }
    public Vector2StatisticCommand(Vector2Statistic id, float value) : this(id, new Vector2(Statistics.instance.Get(FloatStatistic.TimePassed), value)) {
    }
    public void Do() {
        Statistics.instance.Add(id, value);
    }

    public void Undo() {
        Statistics.instance.Remove(id, value);
    }
}
