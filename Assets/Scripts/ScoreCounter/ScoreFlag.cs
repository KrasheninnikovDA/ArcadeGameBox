/// класс - флаг, сингализирующий ScoreCounter что это объект за который надо начислить очки
using UnityEngine;

public class ScoreFlag : MonoBehaviour, IScore
{
    [SerializeField] private int _scoreValue;

    public int ScoreValue => _scoreValue;
}
