
using UnityEngine;

public class DifficultyLevel : MonoBehaviour
{
    [SerializeField] private RoadConfig _roadConfig;
    [SerializeField] private float _durationLevel;
    [SerializeField, Range(1,2)] private float _coefficientOfIncreaseInSpeed;
    private Timer timerLevel;

    private void Start()
    {
        timerLevel = new Timer(_durationLevel, TimerMode.loop);
        timerLevel.ActionStopTimer.Subscribe(IncreaseSpeedRoad);
        timerLevel.Start();
    }

    private void Update()
    {
        timerLevel.Update();
    }

    private void IncreaseSpeedRoad()
    {
        _roadConfig.SpeedRoadbed.Value *= _coefficientOfIncreaseInSpeed;
    }
}
