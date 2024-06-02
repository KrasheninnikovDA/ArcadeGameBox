
using UnityEngine;

public class FirstRoadbedLifeCycle : MonoBehaviour, IDeletedOffScreen, IReadOnlyPosition
{
    [SerializeField] private Transform _trackingPoint;
    [SerializeField] private Transform _dockingPoint;
    [SerializeField] private Transform _destroyPoint;
    public AtomickAction EndLifeCycle => _endLifeCycle;
    public Vector2 Position => _dockingPoint.TransformDirection(_dockingPoint.position);

    private AtomickAction _endLifeCycle = new();
    private Vector2 _pointBorderScreen;
    private bool isSingle = true;

    public void SetPointBorderScreen(Vector2 pointBorderScreen)
    {
        _pointBorderScreen = pointBorderScreen;
    }

    private void Update()
    {
        ChackEndLifeCycle();
    }

    //на старте игры требуется создать 2 Roadbed, что бы игрок не видел стыков
    private void ChackEndLifeCycle()
    {
        if (_trackingPoint.position.y - _pointBorderScreen.y < 0 && isSingle)
        {
            _endLifeCycle.Invoke();
            _endLifeCycle.Invoke();
            isSingle = false;
        }

        if (_destroyPoint.position.y - _pointBorderScreen.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
