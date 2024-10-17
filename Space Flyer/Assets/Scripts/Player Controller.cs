using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 10f;   // Movement speed
    public float diagonalSpeed = 5f;  // Speed for diagonal movement

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
            // Move diagonally upward (positive y direction)
            rb.velocity = new Vector2(speed, diagonalSpeed);
        }
        else
        {
            // Move diagonally downward (negative y direction) when input is released
            rb.velocity = new Vector2(speed, -diagonalSpeed);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the y position of the other object
        float otherY = collision.transform.position.y;

        // Check if the y position of the other object is approximately the same as the player's y position
        if (Mathf.Abs(otherY - transform.position.y) < 0.1f)  // Adjust tolerance as needed
        {
            // Destroy the player when the y-axis match is detected
            Destroy(gameObject);
        }
    }
}
