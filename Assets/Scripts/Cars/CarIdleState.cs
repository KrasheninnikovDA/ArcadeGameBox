/// класс - состояние. реализует AbsState. запускается из состояния CarMoveState через SwitcherState
/// реализует движение машины по вертикали вместе с дорожным полотном
/// по истечении таймера _idleTimer переключит состояние на CarMoveState
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarIdleState : AbsState, INeedyConfigForMovement, IAnimated, ISwitchable
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

    private void Start()
    {
        _moveMechanics = new(GetComponent<Rigidbody2D>());
    }

    public void SetConfig(RoadConfig roadConfig)
    {
        _verticalSpeed = roadConfig.SpeedRoadbed;
        _verticlDirection = roadConfig.DirectionOfMovementIsDown;
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

    public override void СontrolledUpdate()
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
