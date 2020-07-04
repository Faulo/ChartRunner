using UnityEngine;


public abstract class Effect : ScriptableObject {
    public abstract void Invoke(GameObject context);
}
