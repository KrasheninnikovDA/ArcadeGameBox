/// класс переключатель сцен
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerExpansion : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(GameConstant.IndexStartGameScene);
    }

    public void OpenScene(int indexSceneToOpen)
    {
        SceneManager.LoadScene(indexSceneToOpen);
    }
}
