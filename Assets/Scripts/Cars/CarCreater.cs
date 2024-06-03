
using Unity.VisualScripting;
using UnityEngine;

public class CarCreater : MonoBehaviour, INeedyConfForMovement
{
    [SerializeField] private PrefabCarPointPair[] _carPointPairs;
    private RoadConfig _roadConfig;

    public void Construct(RoadConfig roadConfig)
    {
        _roadConfig = roadConfig;
        Create();
    }

    public void Create()
    {
        foreach (PrefabCarPointPair prefabCarPointPair in _carPointPairs)
        {
            GameObject prefCar = prefabCarPointPair.PrefCar;
            Vector2 placementPoints = prefabCarPointPair.PlacementPoints;
            GameObject car = Instantiate(prefCar, placementPoints, Quaternion.identity);
            InstallDependencies(car);
        }
    }

    private void InstallDependencies(GameObject car)
    {
        car.transform.parent = transform;

        INeedyConfForMovement[] needyConfForMovement = car.GetComponentsInChildren<INeedyConfForMovement>();
        foreach (INeedyConfForMovement needy in needyConfForMovement)
        {
            needy.Construct(_roadConfig);
        }

        IPlayingAnimations playingAnimations = car.GetComponentInChildren<IPlayingAnimations>();
        IAnimated[] animateds = car.GetComponentsInChildren<IAnimated>();
        foreach(IAnimated animated in animateds) 
        {
            animated.SetPlayerAnimation(playingAnimations);
        }
    }
}
