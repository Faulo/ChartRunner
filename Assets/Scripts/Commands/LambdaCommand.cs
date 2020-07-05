using System;

public class LambdaCommand : IUndoable {
    Action doCallback;
    Action undoCallback;

    public LambdaCommand(Action doCallback, Action undoCallback) {
        this.doCallback = doCallback;
        this.undoCallback = undoCallback;
    }
    public void Do() {
        doCallback();
    }
    public void Undo() {
        undoCallback();
    }
}
