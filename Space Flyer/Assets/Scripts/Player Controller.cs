using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 10f;
    public float diagonalSpeed = 5f;
    public GameObject explosionPrefab;
    public AudioClip explosionSound;         // Reference to the explosion sound

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component for controlling physics-based movement
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for input (e.g., space bar or mouse click) to move diagonally upward
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            rb.velocity = new Vector2(speed, diagonalSpeed);
        }
        else
        {
            rb.velocity = new Vector2(speed, -diagonalSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Rocks"
        if (collision.gameObject.CompareTag("Rocks"))
        {
            // Instantiate the explosion prefab at the ship's position and rotation
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            AudioSource.PlayClipAtPoint(explosionSound, transform.position);

            // Destroy the player's GameObject
            Destroy(gameObject);

            // Optional: Debug log for collision event
            print("boom");
        }
    }
}

