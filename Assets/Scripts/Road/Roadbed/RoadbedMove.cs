
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RoadbedMove : MonoBehaviour, INeedyConfForMovement
{
    private Variable<float> _speed;
    private float _directionMove;
    private Rigidbody2D _rb;
    private MoveMechanics moveMechanics;

    public void Construct(RoadConfig roadConfig)
    {
        _speed = roadConfig.SpeedRoadbed;
        _directionMove = roadConfig.DirectionOfMovementIsDown;
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        moveMechanics = new (_rb);
    }

    private void Update()
    {
        moveMechanics.MoveVertically(_directionMove, _speed.Value);
    }
}
