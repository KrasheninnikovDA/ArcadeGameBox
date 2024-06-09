/// перезапуск игры (конопка на последней сцене)
using UnityEngine;

public class RestartGameButton : MonoBehaviour
{
    public void Restart()
    {
        Game.SceneManagerExpansion.RestartGame();
    }
}
