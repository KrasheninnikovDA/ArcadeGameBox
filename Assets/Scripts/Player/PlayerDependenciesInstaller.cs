
using UnityEngine;

public class PlayerDependenciesInstaller : MonoBehaviour
{
    [SerializeField] private SwitcherState _switcherState;
    [SerializeField] private AnimatorOfStates _animatorOfStates;
    [SerializeField] private AudioSourceOfState _audioSourceOfState;
    [SerializeField] private AbsInput _input;
    [SerializeField] private RoadConfig _roadConfig;

    public void InstallDependencies()
    {
        _switcherState.Construct();

        INeedyConfigForMovement[] needyConfForMovements = GetComponents<INeedyConfigForMovement>();
        foreach (INeedyConfigForMovement needyConfForMovement in needyConfForMovements)
        {
            needyConfForMovement.SetConfig(_roadConfig);
        }

        IAnimated[] animateds = GetComponents<IAnimated>();
        foreach (IAnimated animated in animateds)
        {
            animated.SetPlayerAnimation(_animatorOfStates);
        }

        ISwitchable[] switchables = GetComponents<ISwitchable>();
        foreach (ISwitchable switchable in switchables)
        {
            switchable.SetSwitherState(_switcherState);
        }

        IVoiced[] voiceds = GetComponents<IVoiced>();
        foreach (IVoiced voiced in voiceds)
        {
            voiced.SetAudioSource(_audioSourceOfState);
        }

        IRequiringInput[] requiringInputs = GetComponents<IRequiringInput>();
        foreach (IRequiringInput requiringInput in requiringInputs)
        {
            requiringInput.SetInput(_input);
        }
    }
}
