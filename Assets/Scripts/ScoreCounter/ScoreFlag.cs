/// ����� - ����, ��������������� ScoreCounter ��� ��� ������ �� ������� ���� ��������� ����
using UnityEngine;

public class ScoreFlag : MonoBehaviour, IScore
{
    [SerializeField] private int _scoreValue;

    public int ScoreValue => _scoreValue;
}
