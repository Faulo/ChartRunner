using UnityEngine;

public class EventCommand : IUndoable {
    GameObject context;
    GameObjectEvent callback;
    public EventCommand(GameObject context, GameObjectEvent callback) {
        this.context = context;
        this.callback = callback;
    }

    public void Do() {
        callback.Invoke(context);
    }

    public void Undo() {
        callback.Invoke(context);
    }
}
