
using UnityEngine;

public abstract class AbsState : MonoBehaviour
{
    //при создании экземпляра
    public abstract void Construct();
    //при установке как действующего состояния
    public abstract void Initialize();
    //каждый кадр когда действует
    public abstract void СontrolledUpdate();
    //при отключении состояния
    public abstract void Unplug();
}
