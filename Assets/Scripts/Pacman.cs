using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    private Movement movement;
    private new Collider2D collider;

    public Vector3 startPosition = new Vector3(0, -9.5f, 0); // Başlangıç pozisyonu için yeni bir değişken

    private void Awake()
    {
        movement = GetComponent<Movement>();
        collider = GetComponent<Collider2D>();
        startPosition = transform.position; // Başlangıç pozisyonunu ayarla
    }

    private void Start()
    {
        // Pacman'in başlangıç pozisyonunu ayarlayın
        transform.position = startPosition;
    }

    private void Update()
    {
        // Set the new direction based on the current input
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            movement.SetDirection(Vector2.right);
        }

        // Rotate pacman to face the movement direction
        Vector2 direction = movement.direction;
        if (direction != Vector2.zero) {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ResetState()
    {
        enabled = true;
        collider.enabled = true;
        movement.ResetState();
        transform.position = startPosition; // Başlangıç pozisyonunu kullan
        gameObject.SetActive(true);
    }

    public void DeathSequence()
    {
        // Disable Pacman
        enabled = false;
        collider.enabled = false;
        movement.enabled = false;
        gameObject.SetActive(false); // Disable the entire GameObject
    }
}
