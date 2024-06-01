
public class TimeDilationMechanics
{
    private Variable<float> _speedRoadbed;
    private float _deceleration;
    private float _speedAtMomentOfDeceleration;

    public TimeDilationMechanics (Variable<float> speedRoadbed, float deceleration)
    {
        _speedRoadbed = speedRoadbed;
        _deceleration = deceleration;
    }

    public void GiveSignalToSlowDown(bool signalOfBeginningOfDeceleration, bool signalForEndOfDeceleration)
    {
        if (signalOfBeginningOfDeceleration)
        {
            SlowDown();
        }

        if (signalForEndOfDeceleration)
        {
            EndSlowDown();
        }
    }

    private void SlowDown()
    {
        _speedAtMomentOfDeceleration = _speedRoadbed.Value;
        float slowSpeed = _speedRoadbed.Value * _deceleration;
        _speedRoadbed.Value = slowSpeed;
    }

    private void EndSlowDown()
    {
        _speedRoadbed.Value = _speedAtMomentOfDeceleration;
    }
}
