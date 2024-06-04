
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour, ISwitchable
{
    private SwitcherState _switerState;
    public void SetSwitherState(SwitcherState switcherState)
    {
        _switerState = switcherState;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICrashed crashed = collision.gameObject.GetComponent<ICrashed>();
        if (crashed != null) 
        {
            crashed.Crash();
            _switerState.Switch(StateName.Crash);
        }
    }
}
