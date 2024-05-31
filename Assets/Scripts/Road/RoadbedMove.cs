
using UnityEngine;

public class RoadbedMove : MonoBehaviour
{
    private Variable<float> _speed;
    private Rigidbody2D _rb;

    public void Create(Variable<float> speed)
    {
        _speed = speed;
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        
    }
}
