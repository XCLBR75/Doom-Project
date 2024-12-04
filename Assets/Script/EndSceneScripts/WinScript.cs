using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject bossEnemy; // Assign the boss enemy object in the Inspector
    public float transitionDelay = 1f; // Delay before transitioning to the credits scene
    public int creditsSceneIndex = 2;

    void Update()
    {
        // Check if the boss enemy is null or destroyed
        if (bossEnemy == null)
        {
            // Load the credits scene
            SceneManager.LoadScene(creditsSceneIndex);
            StartCoroutine(TransitionToCredits());
        }
    }

    private IEnumerator TransitionToCredits()
    {
        // Ensure this coroutine only runs once
        enabled = false;

        yield return new WaitForSeconds(transitionDelay);

        // Load the credits scene
        SceneManager.LoadScene(creditsSceneIndex);
    }
}
