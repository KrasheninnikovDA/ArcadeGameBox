/// ����� - ���������. ��������� AbsState. ����������� ��� ������������
/// ����� Unplug ������ �� ���������, ��� ��� ��� �������� ��������� ������. 
/// �� ��������� ������� _crashTimer ������ ����� ����������
using UnityEngine;

public class CarCrashState : AbsState, IAnimated
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private float _durationState;
    [SerializeField] private StateName _nameNextState;
    [SerializeField] private BoxCollider2D _boxCollider;

    public string NameAnimation => _nameAnimation;
    public override StateName NameState => StateName.Crash;

    private IPlayingAnimations _animationPlayer;
    private Timer _crashTimer;

    public void SetPlayerAnimation(IPlayingAnimations animationPlayer)
    {
        _animationPlayer = animationPlayer;
    }

    public override void Initialize()
    {
        _boxCollider.enabled = false;
        _crashTimer = new(_durationState, TimerMode.singlnes);
        _crashTimer.ActionStopTimer.Subscribe(DestroyCar);
        _crashTimer.Start();
    }

    public override void �ontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        _crashTimer.Update();
    }

    public override void Unplug()
    {
    }

    private void DestroyCar()
    {
        Destroy(gameObject);
    }
}
