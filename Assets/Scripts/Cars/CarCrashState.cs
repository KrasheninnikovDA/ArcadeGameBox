
using UnityEngine;

public class CarCrashState : AbsState, IAnimated, ISwitchable
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private float _durationState;
    [SerializeField] private StateName _nameNextState;
    [SerializeField] private BoxCollider2D _boxCollider;

    public string NameAnimation => _nameAnimation;
    public override StateName NameState => StateName.Crash;

    private SwitcherState _switcherState;
    private IPlayingAnimations _animationPlayer;
    private Timer _crashTimer;

    public void SetPlayerAnimation(IPlayingAnimations animationPlayer)
    {
        _animationPlayer = animationPlayer;
    }

    public void SetSwitherState(SwitcherState switcherState)
    {
        _switcherState = switcherState;
    }

    public override void Initialize()
    {
        _boxCollider.enabled = false;
        _crashTimer = new(_durationState, TimerMode.singlnes);
        _crashTimer.ActionStopTimer.Subscribe(SwitchToNextState);
        _crashTimer.Start();
    }

    public override void ÑontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        _crashTimer.Update();
    }

    public override void Unplug()
    {
        Destroy(gameObject);
    }

    private void SwitchToNextState()
    {
        _switcherState.Switch(_nameNextState);
    }
}
