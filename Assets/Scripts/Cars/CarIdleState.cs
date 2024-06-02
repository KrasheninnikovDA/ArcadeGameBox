using System;
using UnityEngine;

public class CarIdleState : AbsState, IAnimated
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private float _durationState;
    public string NameAnimation => _nameAnimation;

    private SwitcherState _switcherState;
    private Type _nextState = typeof(CarMoveState);
    private IPlayingAnimations _animationPlayer;
    private Timer _idleTimer;

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
        _idleTimer = new(_durationState, TimerMode.singlnes);
        _idleTimer.ActionStopTimer.Subscribe(SwitchToNextState);
        _idleTimer.Start();
    }

    public override void ÑontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        _idleTimer.Update();
    }

    public override void Unplug()
    {
        _idleTimer.ActionStopTimer.Unsubscribe(SwitchToNextState);
    }

    protected override void SwitchToNextState()
    {
        _switcherState.Switch(_nextState);
    }
}
