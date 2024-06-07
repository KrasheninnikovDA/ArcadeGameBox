
using UnityEngine;

public class CarsStarter : MonoBehaviour, INeedyConfigForMovement
{
    [SerializeField] private CarDependenciesInstaller[] _cars;

    public void SetConfig(RoadConfig roadConfig)
    {
        foreach(var car in _cars) 
        {
            car.Construct(roadConfig);
        }
    }
}
