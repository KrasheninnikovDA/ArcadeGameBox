using UnityEngine;

enum DirectionMovment 
{
    right = 1, 
    left = -1
}
public class DeterminDirectionMechanics
{
    public AtomickAction EndPathMover { private set; get; }

    private Transform _transformMover;
    private Vector3 _positionTargetPointLeft;
    private Vector3 _positionTargetPointRight;
    private Vector3 _currentTarget;
    private Timer _distanceCheckTimer;
    private DirectionMovment _currentDerection;

    public DeterminDirectionMechanics(Transform transformMover, Vector3 positionTargetPointLeft, Vector3 positionTargetPointRight)
    {
        EndPathMover = new();
        _transformMover = transformMover;
        _positionTargetPointLeft = positionTargetPointLeft;
        _positionTargetPointRight = positionTargetPointRight;
        _currentTarget = GetCurrentTarget();
        _distanceCheckTimer = new(0.3f, TimerMode.singlnes);
        _currentDerection = DirectionMovment.right;
    }

    public float GetCurrentDirection()
    {
        CheckEndPath();
        return (float)_currentDerection;
    }

    private Vector3 GetCurrentTarget()
    {
        Vector2 currentPositionMover = _transformMover.position;
        float distans1 = Vector2.Distance(_positionTargetPointLeft, currentPositionMover);
        float distans2 = Vector2.Distance(_positionTargetPointRight, currentPositionMover);
        return distans1 >= distans2 ? _positionTargetPointRight : _positionTargetPointLeft;
    }

    public void CheckEndPath()
    {
        bool endPathX = Mathf.Abs(_transformMover.position.x - _currentTarget.x) <= 0.1f;
        if (endPathX && !_distanceCheckTimer.Runing)
        {
            SwithDirection();
        }
        _distanceCheckTimer.Update();
    }

    private void SwithDirection()
    {
        _currentTarget = SwitchCurrentTarget();
        _distanceCheckTimer.Start();
    }

    private Vector3 SwitchCurrentTarget()
    {
        if (_currentTarget == _positionTargetPointLeft)
        { 
            _currentDerection = DirectionMovment.left;
            return _positionTargetPointRight; 
        }
        _currentDerection = DirectionMovment.right;
        return _positionTargetPointLeft;
    }
}
