
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class CarMoveState : AbsState, INeedyConfForMovement, IAnimated
{
    [SerializeField] private Variable<float> _horisontalSpeed;
    [SerializeField] private string _nameAnimation;
    [SerializeField] private Transform positionBorderLeft;
    [SerializeField] private Transform positionBorderRight;

    public string NameAnimation => _nameAnimation;
    private IPlayingAnimations _animationPlayer;

    private SwitcherState _switcherState;
    private Type _nextState;

    private Variable<float> _verticalSpeed;
    private float _verticlaDirection;
    private float _horisontalDirection;
    private Rigidbody2D _rb;
    private MoveMechanics moveMechanics;
    private DeterminDirectionMechanics determinDirection;

    public void Construct(RoadConfig roadConfig)
    {
        _rb = GetComponent<Rigidbody2D>();
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
        _horisontalDirection = determinDirection.GetCurrentDirection();
        determinDirection.EndPathMover.Subscribe(SwitchToNextState);
    }

    public override void ÑontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        moveMechanics.MoveVertically(_verticlaDirection, _verticalSpeed.Value);
        moveMechanics.MoveHorizontally(_horisontalDirection, _horisontalSpeed.Value);
        determinDirection.CheckEndPath();
    }

    public override void Unplug()
    {
        determinDirection.EndPathMover.Unsubscribe(SwitchToNextState);
    }

    protected override void SwitchToNextState()
    {
        _switcherState.Switch(_nextState);
    }
}
