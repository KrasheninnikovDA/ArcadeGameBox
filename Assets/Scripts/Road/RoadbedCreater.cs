
using UnityEngine;

public class RoadbedCreater : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefRoadbeds;
    [SerializeField] private GameObject _prefFirstRoadbed;
    [SerializeField] private Transform _startPosition;

    private IReadOnlyPosition _lastPositionRoadbedInQueue;
    private RoadConfig _config;
    private Transform _pointBorderScreen;

    public void Construct(RoadConfig config, Transform pointBorderScreen)
    {
        _config = config;
        _pointBorderScreen = pointBorderScreen;
        Create(_prefFirstRoadbed);
    }

    public void Create()
    {
        int randomIndex = Random.Range(0, _prefRoadbeds.Length - 1);
        GameObject roadbed = Instantiate(_prefRoadbeds[randomIndex], _lastPositionRoadbedInQueue.Position, Quaternion.identity);
        InstallDependencies(roadbed);
    }

    public void Create(GameObject _prefFirstRoadbed)
    {
        GameObject roadbed = Instantiate(_prefFirstRoadbed, _startPosition.TransformDirection(_startPosition.position), Quaternion.identity);
        InstallDependencies(roadbed);
    }

    private void InstallDependencies(GameObject roadbed)
    {
        _lastPositionRoadbedInQueue = roadbed.GetComponent<IReadOnlyPosition>();

        IDeletedOffScreen deletedOffScreen = roadbed.GetComponent<IDeletedOffScreen>();
        deletedOffScreen.EndLifeCycle.Subscribe(Create);
        deletedOffScreen.SetPointBorderScreen(_pointBorderScreen.position);

        roadbed.GetComponent<INeedyConfForMovement>().Construct(_config);
    }
}
