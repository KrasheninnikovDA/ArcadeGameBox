
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
