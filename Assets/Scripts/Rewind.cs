using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rewind : MonoBehaviour {
    public static Rewind instance;

    Stack<ICollection<IUndoable>> timeline = new Stack<ICollection<IUndoable>>();

    void Awake() {
        instance = this;
    }

    public void Do(ICollection<IUndoable> commands) {
        timeline.Push(commands);
        foreach (var command in commands) {
            command.Do();
        }
    }
    public void Undo() {
        if (timeline.Count > 0) {
            foreach (var command in timeline.Pop().Reverse()) {
                command.Undo();
            }
        }
    }
}
