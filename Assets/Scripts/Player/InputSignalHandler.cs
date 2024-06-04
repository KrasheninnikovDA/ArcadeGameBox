using UnityEngine;

public class InputSignalHandler : MonoBehaviour, IRequiringInput, ISwitchable
{
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
    }

    private void EnableMoveStatus(float direction)
    {
        if (Mathf.Abs(direction) > sensitivity)
        {
            _switcherState.Switch(StateName.Move);
            return;
        }
        EnableIdleStatus();
    }

    private void EnableIdleStatus()
    {
        _switcherState.Switch(StateName.Idle);
    }
}
