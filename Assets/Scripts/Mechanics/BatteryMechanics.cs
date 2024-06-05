
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
            _currentContainer = Mathf.Clamp(_currentContainer, 0, _maxContainer);
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
