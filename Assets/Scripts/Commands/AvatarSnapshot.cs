using UnityEngine;

public class AvatarSnapshot {
    public Vector3 position;
    public Vector2 velocity;
    public float acceleration;
    public AvatarState state;

    public override bool Equals(object obj) {
        return obj is AvatarSnapshot other
            ? position == other.position && velocity == other.velocity && acceleration == other.acceleration && state == other.state
            : false;
    }

    public override int GetHashCode() {
        return state.GetHashCode();
    }
}
