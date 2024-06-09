///класс аналогичный GameEntryPoint. позволяет нормально запустить игру из геймплейной сцены
using UnityEngine;

public class InitForTestMod : MonoBehaviour
{
    private void Awake()
    {
        if (!Game.IsInit)
        {
            Game.Init(GetComponent<SceneManagerExpansion>());
        }
    }
}
