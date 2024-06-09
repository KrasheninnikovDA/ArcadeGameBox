/// класс - механика. реализует механику движения объекта отдельно по вертикали и горизонтали
using UnityEngine;

public class MoveMechanics 
{
    private readonly Rigidbody2D _rigidbody2D;
    private const float sensitivity = 0.01f;

    public MoveMechanics (Rigidbody2D rigidbody2D)
    {
        _rigidbody2D = rigidbody2D;
    }

    public void MoveVertically(float directionY, float speed)
    {
        if (ChackValueDirection(directionY))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, directionY * speed);
            return;
        }
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
    }

    public void MoveHorizontally(float directionX, float speed)
    {
        if (ChackValueDirection(directionX))
        {
            _rigidbody2D.velocity = new Vector2(directionX * speed, _rigidbody2D.velocity.y);
            return;
        }
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
    }

    public void Stop()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    private bool ChackValueDirection(float directionValue)
    {
        return Mathf.Abs(directionValue) > sensitivity;
    }
}
