
using UnityEngine;

public class BatteryMechanics 
{
    public bool isCapacity => _currentContainer > 0;
    public float capacityPercentage => _currentContainer / _maxContainer;

    private float _maxContainer;
    private float _currentContainer;
    private bool isRuning;

    public BatteryMechanics(float container)
    {
        _maxContainer = container;
        _currentContainer = container;
        isRuning = false;
    }

    public void StartUsingBattery(bool signalOfBeginningOfDeceleration)
    {
        if (signalOfBeginningOfDeceleration)
        {
            isRuning = true;
        } 
    }

    public void Update()
    {
        if (isRuning)
        {
            _currentContainer -= Time.deltaTime;
        }
    }

    public void StopUsingBattery(bool signalForEndOfDeceleration)
    {
        if (signalForEndOfDeceleration) 
        {
            isRuning = false;
        }
    }
}
