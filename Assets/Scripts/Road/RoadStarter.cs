
using UnityEngine;

public class RoadStarter : MonoBehaviour
{
    [SerializeField] private RoadbedCreater _roadbedCreater;
    [SerializeField] private RoadConfig _config;
    [SerializeField] private Transform _pointBorderScreen;

    void Start()
    {
        _roadbedCreater.Construct(_config, _pointBorderScreen);
    }
}
