using UnityEngine;

public class InputSignalHandler : MonoBehaviour, IRequiringInput
{
    [SerializeField] private SwitcherState _switcherState;
    private AbsInput _input;
    
    public void SetInput(AbsInput input)
    {
        _input = input;
    }

    private void Update()
    {
        EnableMoveStatus(_input.HorizontalMove);
    }

    private void EnableMoveStatus(float direction)
    {
        if (Mathf.Abs(direction) > 0.01f)
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
