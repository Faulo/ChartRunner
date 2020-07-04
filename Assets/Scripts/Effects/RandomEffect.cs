using Slothsoft.UnityExtensions;
using UnityEngine;

[CreateAssetMenu(fileName = "Random_New", menuName = "Effects/Random Effect")]
public class RandomEffect : Effect {
    [SerializeField]
    Effect[] effectsToChooseFrom = new Effect[0];

    public override void Invoke(GameObject context) {
        effectsToChooseFrom.RandomElement().Invoke(context);
    }
}