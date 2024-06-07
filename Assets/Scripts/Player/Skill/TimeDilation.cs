
using UnityEngine;

public class TimeDilation : MonoBehaviour, INeedyConfigForMovement
{
    [SerializeField] private float _decelerationFactor;
    [SerializeField] private float _containerBattery;

    private Variable<float> _speedRoadbed;
    private TimeDilationMechanics _timeDilationMechanics;
    private BatteryMechanics _batteryMechanics;

    public void SetConfig(RoadConfig roadConfig)
    {
        _speedRoadbed = roadConfig.SpeedRoadbed;
        _timeDilationMechanics = new(_speedRoadbed, _decelerationFactor);
        _batteryMechanics = new(_containerBattery);
    }

    public void GiveSignalToSlowDown(bool signalOfBeginningOfDeceleration, bool signalForEndOfDeceleration)
    {
        _batteryMechanics.StartUsingBattery(signalOfBeginningOfDeceleration);
        _batteryMechanics.Update();
        _batteryMechanics.StopUsingBattery(signalForEndOfDeceleration);

        if (_batteryMechanics.isCapacity || signalForEndOfDeceleration)
        {
            SlowDown(signalOfBeginningOfDeceleration, signalForEndOfDeceleration);
        }
    }

    private void SlowDown(bool signalOfBeginningOfDeceleration, bool signalForEndOfDeceleration)
    {
        _timeDilationMechanics.GiveSignalToSlowDown(signalOfBeginningOfDeceleration, signalForEndOfDeceleration);
        Game.EventBus.DischargeBattery.Invoke(_batteryMechanics.capacityPercentage);
    }
}
