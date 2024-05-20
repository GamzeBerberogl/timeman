using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 15f; // Hız parametresi
    public Vector2 direction { get; private set; }
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float speed)
    {
        // Hareketi uygula
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.deltaTime;
        rb.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    public void ResetState()
    {
        direction = Vector2.zero;
        rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        Move(speed); // Hız parametresini kullanarak hareket ettir
    }
}
