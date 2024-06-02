
using System;
using UnityEngine;

public abstract class AbsState : MonoBehaviour
{
    public abstract void SetSwitherState(SwitcherState switcherState);
    //��� ��������� ��� ������������ ���������
    public abstract void Initialize();
    //������ ���� ����� ���������
    public abstract void �ontrolledUpdate();
    //��� ���������� ���������
    public abstract void Unplug();

    protected abstract void SwitchToNextState();
}
