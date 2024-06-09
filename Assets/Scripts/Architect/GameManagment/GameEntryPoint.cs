/// стартова€ точка игры. “очка инициализации класса Game
using UnityEngine;

[RequireComponent(typeof(SceneManagerExpansion))]
public class GameEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        SceneManagerExpansion sceneManager = GetComponent<SceneManagerExpansion>();
        Game.Init(sceneManager);

        Game.EventBus.AddScore.Subscribe(Game.ScoreRepository.AddScore);
        sceneManager.OpenScene(GameConstant.IndexStartMenuScene);
    }
}
