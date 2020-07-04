using UnityEngine;

[CreateAssetMenu(fileName = "Instantiate_New", menuName = "Effects/Instantiate Object")]
public class InstantiateObjectEffect : Effect {
    [SerializeField]
    GameObject prefab = default;
    [SerializeField]
    bool parentToContext = false;

    public override void Invoke(GameObject context) {
        if (parentToContext) {
            Instantiate(prefab, context.transform);
        } else {
            Instantiate(prefab, context.transform.position, prefab.transform.rotation);
        }
    }
}