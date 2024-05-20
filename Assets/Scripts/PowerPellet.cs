using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 8.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pacman"))
        {
            GameManager.Instance.PelletEaten(this);
            GameManager.Instance.PowerPelletEaten(this);
        }
    }
}
