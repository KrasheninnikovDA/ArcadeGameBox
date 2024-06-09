/// класс - состояние. реализует AbsState. запускается если кнопки "лево" или "право" не нажаты
using UnityEngine;

public class PlayerIdleState : AbsState, IAnimated, IVoiced
{
    [SerializeField] private string _nameAnimation;
    [SerializeField] private AudioClip _clip;
    public override StateName NameState => StateName.Idle;
    public string NameAnimation => _nameAnimation;

    public AudioClip AudioClip => _clip;

    private IPlayingAnimations _animationPlayer;
    private IPlayingAudio _audioSource;

    public void SetAudioSource(IPlayingAudio audioSource)
    {
        _audioSource = audioSource;
    }

    public void SetPlayerAnimation(IPlayingAnimations animationPlayer)
    {
        _animationPlayer = animationPlayer;
    }

    public override void Initialize()
    {
        _audioSource.PlayAudioClip(this, true);
    }

    public override void СontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
    }

    public override void Unplug()
    {
        _audioSource.StopAudioClip();
    }

}
