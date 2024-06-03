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
        _currentTarget = positionTargetPointRight;
        _distanceCheckTimer = new(0.3f, TimerMode.singlnes);
        _currentDerection = DirectionMovment.right;
    }

    public float GetCurrentDirection()
    {
        CheckEndPath();
        return (float)_currentDerection;
    }

    public void CheckEndPath()
    {
        bool endPathX = Mathf.Abs(_transformMover.position.x - _currentTarget.x) <= 0.1f;
        if (endPathX && !_distanceCheckTimer.Runing)
        {
            SwithDirection();
            EndPathMover.Invoke();
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
            _currentDerection = DirectionMovment.right;
            return _positionTargetPointRight; 
        }
        _currentDerection = DirectionMovment.left;
        return _positionTargetPointLeft;
    }
}
