
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveState : AbsState, IRequiringInput, IAnimated, IVoiced
{
    [SerializeField] private Variable<float> _horizontalSpeed;
    [SerializeField] private string _nameAnimationMoveLeft;
    [SerializeField] private string _nameAnimationMoveRight;
    [SerializeField] private AudioClip _clip;
    
    public override StateName NameState => StateName.Move;
    public string NameAnimation => GetNameAnimation();
    public AudioClip AudioClip => _clip;

    private AbsInput _input;
    private IPlayingAnimations _animationPlayer;
    private IPlayingAudio _audioSource;
    private MoveMechanics _moveMechanics;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _moveMechanics = new(_rb);
    }

    public void SetInput(AbsInput input)
    {
        _input = input;
    }

    public void SetPlayerAnimation(IPlayingAnimations animationPlayer)
    {
        _animationPlayer = animationPlayer;
    }

    public void SetAudioSource(IPlayingAudio audioSource)
    {
        _audioSource = audioSource;
    }

    public override void Initialize()
    {
        _audioSource.PlayAudioClip(this);
    }

    public override void ÑontrolledUpdate()
    {
        _animationPlayer.PlayAnimation(this);
        _moveMechanics.MoveHorizontally(_input.HorizontalMove, _horizontalSpeed.Value);
    }

    public override void Unplug()
    {
        _audioSource.StopAudioClip();
        _moveMechanics.Stop();
    }

    private string GetNameAnimation()
    {
        if (_input.HorizontalMove > 0)
        {
            return _nameAnimationMoveRight;
        }
        return _nameAnimationMoveLeft;
    }
}
