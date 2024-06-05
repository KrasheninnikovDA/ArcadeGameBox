using UnityEngine;

public class InputSignalHandler : MonoBehaviour, IRequiringInput, ISwitchable
{
    [Header("Skill")]
    [SerializeField] private TimeDilation timeDilation;

    private SwitcherState _switcherState;
    private AbsInput _input;
    private const float sensitivity = 0.01f;

    public void SetInput(AbsInput input)
    {
        _input = input;
    }

    public void SetSwitherState(SwitcherState switcherState)
    {
        _switcherState = switcherState;
    }

    private void Update()
    {
        EnableMoveStatus(_input.HorizontalMove);
        timeDilation.GiveSignalToSlowDown(_input.SignalOfBeginningOfDeceleration, _input.SignalForEndOfDeceleration);
    }

    private void EnableMoveStatus(float direction)
    {
        if (Mathf.Abs(direction) > sensitivity)
        {
            EnableMoveStatus();
            return;
        }
        EnableIdleStatus();
    }

    private void EnableMoveStatus() 
    {
        _switcherState.Switch(StateName.Move);
    }

    private void EnableIdleStatus()
    {
        _switcherState.Switch(StateName.Idle);
    }
}
