
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RoadBorder : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _rb.velocity = Vector2.zero;
    }
}
