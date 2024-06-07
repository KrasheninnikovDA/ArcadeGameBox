using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerExpansion : MonoBehaviour
{
    public int CurrentIndexScene => currentIndexScene;
    private int currentIndexScene = 0;

    public void OpenScene(int indexSceneToOpen)
    {
        CheckLoadedCurrentScene();
        StartCoroutine(NextScene(indexSceneToOpen));
        currentIndexScene = indexSceneToOpen;
    }

    private void CheckLoadedCurrentScene()
    {
        if (currentIndexScene != 0)
        {
            CloseCurrentScene();
        }
    }

    private void CloseCurrentScene()
    {
        StartCoroutine(UnloadCurrentScene());
    }

    private IEnumerator NextScene(int BuildIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(BuildIndex, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }
        asyncOperation.allowSceneActivation = true;
    }

    private IEnumerator UnloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(currentIndexScene);
        yield return null;
    }
}
