
using UnityEngine;

public class PlayerStarter : MonoBehaviour
{
    [SerializeField] private PlayerDependenciesInstaller _installer;
    private void Awake()
    {
        _installer.InstallDependencies();
    }
}
