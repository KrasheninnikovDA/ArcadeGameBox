using System;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherState : MonoBehaviour
{
    [SerializeField] private AbsState[] _states;

    private Dictionary<Type, AbsState> _strategiesMap = new();
    private AbsState _currentState;

    public void Construct()
    {
        foreach (AbsState state in _states)
        {
            _strategiesMap.Add(state.GetType(), state);
            state.SetSwitherState(this);
        }
    }

    public void Switch(Type strategy)
    {
        _currentState?.Unplug();
        _currentState = _strategiesMap[strategy];
        _currentState.Initialize();
    }

    private void Update()
    {
        _currentState?.ÑontrolledUpdate();
    }
}
