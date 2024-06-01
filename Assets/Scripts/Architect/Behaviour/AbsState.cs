
using UnityEngine;

public abstract class AbsState : MonoBehaviour
{
    //��� �������� ����������
    public abstract void Construct();
    //��� ��������� ��� ������������ ���������
    public abstract void Initialize();
    //������ ���� ����� ���������
    public abstract void �ontrolledUpdate();
    //��� ���������� ���������
    public abstract void Unplug();
}
