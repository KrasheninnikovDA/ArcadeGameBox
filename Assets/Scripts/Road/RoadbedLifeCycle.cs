
using UnityEngine;

public class RoadbedLifeCycle : MonoBehaviour, IDeletedOffScreen
{
    [SerializeField] private Transform _trackingPoint;
    public AtomickAction EndLifeCycle => _endLifeCycle;
    private AtomickAction _endLifeCycle = new();

    private Vector2 _pointBorderScreen;

    public void SetPointBorderScreen(Vector2 pointBorderScreen)
    {
        _pointBorderScreen = pointBorderScreen;
    }

    private void Update()
    {
        
    }

    private void ChackEndLifeCycle()
    {
    }
}
