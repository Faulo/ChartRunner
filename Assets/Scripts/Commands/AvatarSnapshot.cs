using UnityEngine;

public class AvatarSnapshot {
    public Vector3 position;
    public Vector2 velocity;
    public AvatarState state;
    public float acceleration;
    public float facing;
    public float drag;
    public float rollTimer;

    public override bool Equals(object obj) {
        return obj is AvatarSnapshot other
            ? position == other.position && velocity == other.velocity && acceleration == other.acceleration && state == other.state && facing == other.facing && drag == other.drag && rollTimer == other.rollTimer
            : false;
    }

    public override int GetHashCode() {
        return state.GetHashCode();
    }
}
