///останавливает игру и переключатеся на сцену конца игры
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void Start()
    {
        Game.EventBus.DeadPlayer.Subscribe(StopGame);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        Game.SceneManagerExpansion.OpenScene(GameConstant.IndexEndScene);
    }
}
