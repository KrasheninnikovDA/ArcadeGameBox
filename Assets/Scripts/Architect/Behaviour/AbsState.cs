
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

    //��� ��������� ��� ������������ ���������
    public abstract void Initialize();
    //������ ���� ����� ���������
    public abstract void �ontrolledUpdate();
    //��� ���������� ���������
    public abstract void Unplug();
}
