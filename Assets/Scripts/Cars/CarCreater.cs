
using UnityEngine;

public class CarCreater : MonoBehaviour
{
    [SerializeField] private PrefabCarPointPair[] _carPointPairs;
    private RoadConfig _roadConfig;

    public void Construct(RoadConfig roadConfig)
    {
        _roadConfig = roadConfig;
    }

    public void Crate(RoadConfig roadConfig)
    {
        foreach (PrefabCarPointPair prefabCarPointPair in _carPointPairs)
        {
            GameObject prefCar = prefabCarPointPair.PrefCar;
            Vector2 placementPoints = prefabCarPointPair.PlacementPoints;
            GameObject car = Instantiate(prefCar, placementPoints, Quaternion.identity);
        }
    }

    private void InstallDependencies(GameObject car)
    {
        car.transform.parent = transform;
        car.GetComponent<INeedyConfForMovement>().Construct(_roadConfig);
    }
}
