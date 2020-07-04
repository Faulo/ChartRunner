using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rewind : MonoBehaviour {
    public static Rewind instance;

    public event Action<ICollection<IUndoable>> onCollectCommands;
    public event Action<GameObject> onStartRewind;
    public event Action<GameObject> onStopRewind;

    Stack<ICollection<IUndoable>> timeline = new Stack<ICollection<IUndoable>>();

    public bool isRewinding {
        get => isRewindingCache;
        set {
            if (isRewindingCache != value) {
                isRewindingCache = value;
                if (value) {
                    onStartRewind?.Invoke(gameObject);
                } else {
                    onStopRewind?.Invoke(gameObject);
                }
            }
        }
    }
    bool isRewindingCache;

    [SerializeField, Range(0, 10)]
    public int rewindSpeed = 1;

    void OnEnable() {
        instance = this;
        isRewindingCache = false;
    }

    void Do() {
        var commands = new List<IUndoable>();
        onCollectCommands?.Invoke(commands);
        timeline.Push(commands);
        foreach (var command in commands) {
            command.Do();
        }
    }
    void Undo() {
        for (int i = 0; i < rewindSpeed; i++) {
            if (timeline.Count > 0) {
                foreach (var command in timeline.Pop().Reverse()) {
                    command.Undo();
                }
            }
        }
    }

    void FixedUpdate() {
        if (isRewinding) {
            Undo();
        } else {
            Do();
        }
    }
}
