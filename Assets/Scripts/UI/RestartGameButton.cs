
using UnityEngine;

public class RestartGameButton : MonoBehaviour
{
    public void Restart()
    {
        Game.SceneManagerExpansion.OpenScene(GameConstant.IndexStartGameScene);
    }
}
