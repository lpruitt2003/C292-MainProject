using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    // Public field to assign the audio clip in the Inspector
    public AudioClip backgroundMusic;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the audio clip to the AudioSource and play it
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        print("music playing");
    }

    void OnDisable()
    {
        // Stop playing music when the level or scene is closed
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
