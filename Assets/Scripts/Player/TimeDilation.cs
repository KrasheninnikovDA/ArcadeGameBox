
using UnityEngine;

public class TimeDilation : MonoBehaviour, INeedyConfForMovement
{
    [SerializeField, Range(0.1f,1)] private Variable<float> _decelerationFactor;
    //добавить механику накопителя
    private Variable<float> _speedRoadbed;
    private TimeDilationMechanics _timeDilationMechanics;

    public void Construct(RoadConfig roadConfig)
    {
        _speedRoadbed = roadConfig.SpeedRoadbed;
        _timeDilationMechanics = new(_speedRoadbed, _decelerationFactor);
    }

    public void GiveSignalToSlowDown(bool signalOfBeginningOfDeceleration, bool signalForEndOfDeceleration)
    {
        _timeDilationMechanics.GiveSignalToSlowDown(signalOfBeginningOfDeceleration, signalForEndOfDeceleration);
    }
}
