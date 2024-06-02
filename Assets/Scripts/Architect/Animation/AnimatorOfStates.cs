
using UnityEngine;

public class AnimatorOfStates : MonoBehaviour, IPlayingAnimations
{
    [SerializeField] private Animator _animator;

    public void PlayAnimation(IAnimated animated)
    {
        _animator.Play(animated.NameAnimation);
    }
}
