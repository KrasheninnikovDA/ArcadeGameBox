using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFlag : MonoBehaviour, IScore
{
    [SerializeField] private int _scoreValue;

    public int ScoreValue => _scoreValue;
}
