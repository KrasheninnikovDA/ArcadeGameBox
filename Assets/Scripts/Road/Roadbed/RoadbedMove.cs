
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RoadbedMove : MonoBehaviour, INeedyConfigForMovement
{
    private Variable<float> _speed;
    private float _directionMove;
    private Rigidbody2D _rb;
    private MoveMechanics moveMechanics;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        moveMechanics = new(_rb);
    }

    public void SetConfig(RoadConfig roadConfig)
    {
        _speed = roadConfig.SpeedRoadbed;
        _directionMove = roadConfig.DirectionOfMovementIsDown;
    }

    private void Update()
    {
        moveMechanics.MoveVertically(_directionMove, _speed.Value);
    }
}
