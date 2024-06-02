using System;
using UnityEngine;

public class CarCollisionDetector : MonoBehaviour, ICrashed
{
    [SerializeField] private SwitcherState _switcherState;
    private Type _nextState = typeof(CarCrashState);

    public void Crash()
    {
        _switcherState.Switch(_nextState);
    }
}
