
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class CarMoveState : AbsState, INeedyConfForMovement, IAnimated
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private StateName _nameNextState;
    [SerializeField] private Variable<float> _horisontalSpeed;

    [SerializeField] private Transform positionBorderLeft;
    [SerializeField] private Transform positionBorderRight;

    public string NameAnimation => _nameAnimation;
    public override StateName NameState => StateName.Move;

    private IPlayingAnimations _animationPlayer;

    private SwitcherState _switcherState;
    private Variable<float> _verticalSpeed;
    private float _verticlDirection;
    private float _horizontalDirection;
    private Rigidbody2D _rb;
    private MoveMechanics moveMechanics;
    private DeterminDirectionMechanics determinDirection;

    public void Construct(RoadConfig roadConfig)
    {
        _rb = GetComponent<Rigidbody2D>();
        _verticalSpeed = roadConfig.SpeedRoadbed;
        _verticlDirection = roadConfig.DirectionOfMovementIsDown;
        moveMechanics = new(_rb);
        determinDirection = new(transform, positionBorderLeft.position, positionBorderRight.position);
    }

    public override void SetSwitherState(SwitcherState switcherState)
    {
        _switcherState = switcherState;
    }

    public void SetPlayerAnimation(IPlayingAnimations animationPlayer)
    {
        _animationPlayer = animationPlayer;
    }

    public override void Initialize()
    {
        _horizontalDirection = determinDirection.GetCurrentDirection();
        determinDirection.EndPathMover.Subscribe(SwitchToNextState);
    }

    public override void ÑontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        moveMechanics.MoveVertically(_verticlDirection, _verticalSpeed.Value);
        moveMechanics.MoveHorizontally(_horizontalDirection, _horisontalSpeed.Value);
        determinDirection.CheckEndPath();
    }

    public override void Unplug()
    {
        moveMechanics.MoveHorizontally(0, 0);
        determinDirection.EndPathMover.Unsubscribe(SwitchToNextState);
    }

    protected override void SwitchToNextState()
    {
        _switcherState.Switch(_nameNextState);
    }
}
