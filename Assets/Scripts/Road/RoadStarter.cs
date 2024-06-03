
using UnityEngine;

public class RoadStarter : MonoBehaviour
{
    [SerializeField] private RoadbedCreater _roadbedCreater;
    [SerializeField] private RoadConfig _config;
    [SerializeField] private Transform _pointBorderScreen;

    void Awake()
    {
        _roadbedCreater.Construct(_config, _pointBorderScreen);
    }
}
