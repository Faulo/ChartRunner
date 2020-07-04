using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadScene_New", menuName = "Effects/LoadScene")]
public class LoadSceneEffect : Effect {
    [SerializeField]
    string scene = "";

    public override void Invoke(GameObject context) {
        SceneManager.LoadScene(scene == "" ? SceneManager.GetActiveScene().name : scene);
    }
}