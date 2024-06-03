
using UnityEngine;

public enum StateName
{
    Idle,
    Move,
    Crash
}
public abstract class AbsState : MonoBehaviour
{
    public abstract StateName NameState { get; }
    public abstract void SetSwitherState(SwitcherState switcherState);
    //при установке как действующего состояния
    public abstract void Initialize();
    //каждый кадр когда действует
    public abstract void СontrolledUpdate();
    //при отключении состояния
    public abstract void Unplug();

    protected abstract void SwitchToNextState();
}
