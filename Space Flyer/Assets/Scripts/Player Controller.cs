using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float diagonalSpeed = 5f;
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    public float cameraStopXPosition = 97.14f;  // The x position at which the camera disconnects
    public GameObject endGamePanel;             // Reference to the end game UI panel


    private Rigidbody2D rb;
    private Camera mainCamera;
    private bool cameraDisconnected = false;

    void Start()
    {
        // Get the Rigidbody2D component for controlling physics-based movement
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;  // Get the main camera
        endGamePanel.SetActive(false);
    }

    void Update()
    {
        // Check if the player has reached the x position where the camera should stop following
        if (!cameraDisconnected && transform.position.x >= cameraStopXPosition)
        {
            cameraDisconnected = true;  // Mark camera as disconnected
        }

        if (cameraDisconnected)
        {
            // Move the player in a straight line off-screen
            rb.velocity = new Vector2(speed, 0);
            endGamePanel.SetActive(true);
        }
        else
        {
            // Diagonal movement based on input until the camera disconnects
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                rb.velocity = new Vector2(speed, diagonalSpeed);
            }
            else
            {
                rb.velocity = new Vector2(speed, -diagonalSpeed);
            }

            // Make the camera follow the player's x position while connected
            mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Rocks"
        if (collision.gameObject.CompareTag("Rocks"))
        {
            // Instantiate the explosion prefab at the ship's position and rotation
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Play the explosion sound at the player's position
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);

            // Destroy the player's GameObject
            Destroy(gameObject);

            endGamePanel.SetActive(true);
        }
    }
}