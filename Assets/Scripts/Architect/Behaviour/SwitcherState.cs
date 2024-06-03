
using System.Collections.Generic;
using UnityEngine;

public class SwitcherState : MonoBehaviour
{
    [SerializeField] private AbsState[] _states;

    private Dictionary<StateName, AbsState> _strategiesMap = new();
    private AbsState _currentState;

    public void Construct()
    {
        foreach (AbsState state in _states)
        {
            _strategiesMap.Add(state.NameState, state);
        }
    }

    public void Switch(StateName stateName)
    {
        _currentState?.Unplug();
        _currentState = _strategiesMap[stateName];
        _currentState.Initialize();
    }

    private void Update()
    {
        _currentState?.ÑontrolledUpdate();
    }
}
