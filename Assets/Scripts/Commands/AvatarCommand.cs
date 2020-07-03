using System;

public class AvatarCommand : IUndoable {
    AvatarSnapshot oldState;
    AvatarSnapshot newState;
    Action<AvatarSnapshot> applier;
    public AvatarCommand(AvatarSnapshot oldState, AvatarSnapshot newState, Action<AvatarSnapshot> applier) {
        this.oldState = oldState;
        this.newState = newState;
        this.applier = applier;
    }

    public void Do() {
        applier(newState);
    }

    public void Undo() {
        applier(oldState);
    }
}
