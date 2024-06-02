
using UnityEngine;

public class CarCrashState : AbsState, IAnimated
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private float _durationState;
    public string NameAnimation => _nameAnimation;

    private SwitcherState _switcherState;
    private IPlayingAnimations _animationPlayer;
    private Timer _crashTimer;

    public void SetPlayerAnimation(IPlayingAnimations animationPlayer)
    {
        _animationPlayer = animationPlayer;
    }

    public override void SetSwitherState(SwitcherState switcherState)
    {
        _switcherState = switcherState;
    }

    public override void Initialize()
    {
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

    protected override void SwitchToNextState()
    {
        _switcherState.Switch(typeof(CarCrashState));
    }
}
