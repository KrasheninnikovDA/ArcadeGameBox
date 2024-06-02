
using UnityEngine;

public class CarStarter : MonoBehaviour
{
    [SerializeField] private AnimatorOfStates _animatorOfStates;

    public void Construct()
    {
        IAnimated[] animateds = GetComponents<IAnimated>();
        foreach (IAnimated animated in animateds)
        {
            animated.SetPlayerAnimation(_animatorOfStates);
        }
    }
}
