using UnityEngine;

[CreateAssetMenu(fileName = "Impulse", menuName = "ScriptableObjects/Impulse", order = 1)]
public class Impulse : ScriptableObject {
    public ImpulseStrength strength = default;

    public void StartImpulse() {
        ShakeImpulseManager.instance.FireImpulse(strength);
    }
}
