public class FloatStatisticCommand : IUndoable {
    FloatStatistic id;
    float value;

    public FloatStatisticCommand(FloatStatistic id, float value) {
        this.id = id;
        this.value = value;
    }
    public void Do() {
        Statistics.instance.Add(id, value);
    }

    public void Undo() {
        Statistics.instance.Remove(id, value);
    }
}
