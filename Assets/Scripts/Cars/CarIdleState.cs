using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarIdleState : AbsState, INeedyConfForMovement, IAnimated, ISwitchable
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private float _durationState;
    [SerializeField] private StateName _nameNextState;
    public string NameAnimation => _nameAnimation;
    public override StateName NameState => StateName.Idle;

    private SwitcherState _switcherState;
    private IPlayingAnimations _animationPlayer;
    private Timer _idleTimer;

    private MoveMechanics _moveMechanics;
    private Variable<float> _verticalSpeed;
    private float _verticlDirection;

    public void Construct(RoadConfig roadConfig)
    {
        _verticalSpeed = roadConfig.SpeedRoadbed;
        _verticlDirection = roadConfig.DirectionOfMovementIsDown;
        _moveMechanics = new(GetComponent<Rigidbody2D>());
    }

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
        _idleTimer = new(_durationState, TimerMode.singlnes);
        _idleTimer.ActionStopTimer.Subscribe(SwitchToNextState);
        _idleTimer.Start();
    }

    public override void ÑontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        _moveMechanics.MoveVertically(_verticlDirection, _verticalSpeed.Value);
        _idleTimer.Update();
    }

    public override void Unplug()
    {
        _idleTimer.ActionStopTimer.Unsubscribe(SwitchToNextState);
    }

    private void SwitchToNextState()
    {
        _switcherState.Switch(_nameNextState);
    }
}
