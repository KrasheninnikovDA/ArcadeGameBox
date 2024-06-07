
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        Game.SceneManagerExpansion.OpenScene(GameConstant.IndexGameplayScene);
    }
}
