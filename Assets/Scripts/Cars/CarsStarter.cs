
using UnityEngine;

public class CarsStarter : MonoBehaviour, INeedyConfForMovement
{
    [SerializeField] private CarDependenciesInstaller[] _cars;

    public void Construct(RoadConfig roadConfig)
    {
        foreach(var car in _cars) 
        {
            car.Construct(roadConfig);
        }
    }
}
