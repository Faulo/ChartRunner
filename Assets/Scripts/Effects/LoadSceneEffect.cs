using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadScene_New", menuName = "Effects/LoadScene")]
public class LoadSceneEffect : Effect {
    [SerializeField]
    string scene = "";
    [SerializeField, Range(0, 10)]
    float delay = 0;
    [SerializeField]
    bool reloadCurrentLevel = false;
    [SerializeField]
    bool loadNextLevel = false;

    int nextSceneIndex => SceneManager.GetActiveScene().buildIndex + 1;
    string sceneName => reloadCurrentLevel
        ? SceneManager.GetActiveScene().name
        : scene;

    public override void Invoke(GameObject context) {
        var avatar = FindObjectOfType<AvatarController>();
        if (avatar && !Rewind.instance.isRewinding) {
            Rewind.instance.rewindDisabled = true;

            var coroutine = loadNextLevel
                ? LoadScene(nextSceneIndex)
                : LoadScene(sceneName);
            avatar.StartCoroutine(coroutine);
            avatar.attachedRigidbody.drag = 4;
        }
    }

    IEnumerator LoadScene(string name) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name);
    }

    IEnumerator LoadScene(int index) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }
}