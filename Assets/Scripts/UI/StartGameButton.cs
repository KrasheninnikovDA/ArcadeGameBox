/// переход на сцену с гейплеем (кнопка на сцене со страторым меню)
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1;
        Game.SceneManagerExpansion.OpenScene(GameConstant.IndexGameplayScene);
    }
}
