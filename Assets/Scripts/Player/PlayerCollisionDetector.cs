/// класс - детектор столкновения машины. 
/// переключает состояние игрока и машины, с которой тот столкнулся в состояние Crash
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour, ISwitchable
{
    private SwitcherState _switerState;
    private ICrashed player;

    private void Start()
    {
        player = GetComponent<ICrashed>();
    }

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
            player.Crash();
            _switerState.Switch(StateName.Crash);
        }
    }
}
