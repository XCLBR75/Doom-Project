using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound; // Assign this in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the current GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Play the sound effect
        }
    }
}
