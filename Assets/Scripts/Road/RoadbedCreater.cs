
using UnityEngine;

public class RoadbedCreater : MonoBehaviour
{
    private GameObject[] _prefRoadbeds;
    private IReadOnlyPosition _lastPositionRoadbedInQueue;

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        int randomIndex = Random.Range(0, _prefRoadbeds.Length - 1);
        GameObject roadbed = GameObject.Instantiate(_prefRoadbeds[randomIndex], _lastPositionRoadbedInQueue.Position, Quaternion.identity);
        _lastPositionRoadbedInQueue = roadbed.GetComponent<IReadOnlyPosition>();
        roadbed.GetComponent<IDeletedOffScreen>().EndLifeCycle.Subscribe(Create);
    }
}
