
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
        INeedyConfForMovement[] needyConfForMovement = GetComponentsInChildren<INeedyConfForMovement>();
        foreach (INeedyConfForMovement needy in needyConfForMovement)
        {
            needy.Construct(roadConfig);
        }

        IAnimated[] animateds = GetComponentsInChildren<IAnimated>();
        foreach (IAnimated animated in animateds)
        {
            animated.SetPlayerAnimation(_animatorOfStates);
        }
    }
}
