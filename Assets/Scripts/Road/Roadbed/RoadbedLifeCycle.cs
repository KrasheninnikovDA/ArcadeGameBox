
using UnityEngine;

public class RoadbedLifeCycle : MonoBehaviour, IDeletedOffScreen, IReadOnlyPosition
{
    [SerializeField] private Transform _trackingPoint;
    public AtomickAction EndLifeCycle => _endLifeCycle;
    public Vector2 Position => _trackingPoint.TransformDirection(_trackingPoint.position);
    
    private AtomickAction _endLifeCycle = new();
    private Vector2 _pointBorderScreen;

    public void SetPointBorderScreen(Vector2 pointBorderScreen)
    {
        _pointBorderScreen = pointBorderScreen;
    }

    private void Update()
    {
        ChackEndLifeCycle();
    }

    private void ChackEndLifeCycle()
    {
        if (_trackingPoint.position.y - _pointBorderScreen.y < 0)
        {
            _endLifeCycle.Invoke();
            Destroy(gameObject);
        }
    }
}
