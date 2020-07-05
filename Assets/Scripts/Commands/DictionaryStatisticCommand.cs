public class DictionaryStatisticCommand : IUndoable {
    DictionaryStatistic id;
    string name;
    float value;

    public DictionaryStatisticCommand(DictionaryStatistic id, string name, float value) {
        this.id = id;
        this.name = name;
        this.value = value;
    }
    public void Do() {
        Statistics.instance.Add(id, name, value);
    }
    public void Undo() {
        Statistics.instance.Remove(id, name, value);
    }
}
