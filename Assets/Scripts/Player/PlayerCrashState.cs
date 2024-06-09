/// класс - состояние. реализаует AbsState. 
/// замедляет дорожное полотно до 0, отключает коллайдер игрока, с течением времени постепенно по AnimationCurve разгоняет полотно до прежней скорости
/// по истечении таймера _timerCrash переключает на состояние Idle
using UnityEngine;

public class PlayerCrashState : AbsState, INeedyConfigForMovement, IAnimated, IVoiced, ISwitchable
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private InputSignalHandler _inputSignalHandler;
    [SerializeField] private AnimationCurve _accelerationСurve;
    [SerializeField] private float _durationOfAccident;

    public override StateName NameState => StateName.Crash;
    public string NameAnimation => _nameAnimation;
    public AudioClip AudioClip => _clip;

    private Variable<float> _speedRoad;
    private IPlayingAudio _audioSource;
    private IPlayingAnimations _animationPlayer;
    private SwitcherState _switcherState;
    private float _speedAtMomentOfCrash;
    private Timer _timerCrash;

    public void SetConfig(RoadConfig roadConfig)
    {
        _speedRoad = roadConfig.SpeedRoadbed;
    }

    public void SetAudioSource(IPlayingAudio audioSource)
    {
        _audioSource = audioSource;
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
        OnAudioSource();
        DisableMachineControl();
        StopCar();
        InitializeTimer();
    }

    public override void СontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        _timerCrash.Update();
        Disperse();
    }

    public override void Unplug()
    {
        OffAudioSource();
        EnableMechinControl();
        _timerCrash.ActionStopTimer.Unsubscribe(SwitchToNextState);
    }

    private void OnAudioSource()
    {
        _audioSource.PlayAudioClip(this, false);
    }

    private void OffAudioSource()
    {
        _audioSource.StopAudioClip();
    }

    private void DisableMachineControl()
    {
        _inputSignalHandler.enabled = false;
        _boxCollider2D.enabled = false;
    }

    private void EnableMechinControl()
    {
        _inputSignalHandler.enabled = true;
        _boxCollider2D.enabled = true;
    }

    private void StopCar()
    {
        _speedAtMomentOfCrash = _speedRoad.Value;
        _speedRoad.Value = 0;
    }

    private void InitializeTimer()
    {
        _timerCrash = new(_durationOfAccident, TimerMode.singlnes);
        _timerCrash.ActionStopTimer.Subscribe(SwitchToNextState);
        _timerCrash.Start();
    }

    private void SwitchToNextState()
    {
        _switcherState.Switch(StateName.Idle);
    }

    private void Disperse()
    {
        _speedRoad.Value = _speedAtMomentOfCrash * _accelerationСurve.Evaluate(_timerCrash.PercentageOfCompletion);
    }
}
