/// класс через который передается информация по параметрам вертикального движения
using UnityEngine;

public class RoadConfig : MonoBehaviour
{
    [SerializeField] Variable<float> _speedRoadbed;
    public Variable<float> SpeedRoadbed => _speedRoadbed;
    public float DirectionOfMovementIsDown => -1.0f;

}
