/// класс установщик зависимостей.
using UnityEngine;

public class CarDependenciesInstaller : MonoBehaviour
{
    [SerializeField] private SwitcherState _switcherState;
    [SerializeField] private AnimatorOfStates _animatorOfStates;

    public void Construct(RoadConfig roadConfig)
    {
        InstallDependencies(roadConfig);
        _switcherState.Construct();
        _switcherState.Switch(StateName.Idle);
    }

    private void InstallDependencies(RoadConfig roadConfig)
    {
        INeedyConfigForMovement[] needyConfForMovement = GetComponentsInChildren<INeedyConfigForMovement>();
        foreach (INeedyConfigForMovement needy in needyConfForMovement)
        {
            needy.SetConfig(roadConfig);
        }

        IAnimated[] animateds = GetComponentsInChildren<IAnimated>();
        foreach (IAnimated animated in animateds)
        {
            animated.SetPlayerAnimation(_animatorOfStates);
        }

        ISwitchable[] switchables = GetComponentsInChildren<ISwitchable>();
        foreach (ISwitchable switchable in switchables)
        {
            switchable.SetSwitherState(_switcherState);
        }
    }
}
