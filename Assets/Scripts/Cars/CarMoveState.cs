/// класс - состояние. реализует AbsState. запускается из состояния CarIdleState через SwitcherState
/// реализует движение машины, как по вертикали, вместе с дорожным полотном, так и по горизонтали
/// при достчижении крайней точки направления текущего движения по горизонтали меняет состояние на CarIdleState 
/// а направление движения на противоположное
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class CarMoveState : AbsState, INeedyConfigForMovement, IAnimated, ISwitchable
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

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        moveMechanics = new(_rb);
        determinDirection = new(transform, positionBorderLeft.position, positionBorderRight.position);
    }

    public void SetConfig(RoadConfig roadConfig)
    {
        _verticalSpeed = roadConfig.SpeedRoadbed;
        _verticlDirection = roadConfig.DirectionOfMovementIsDown;
    }

    public void SetSwitherState(SwitcherState switcherState)
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

    public override void СontrolledUpdate()
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

    private void SwitchToNextState()
    {
        _switcherState.Switch(_nameNextState);
    }
}
