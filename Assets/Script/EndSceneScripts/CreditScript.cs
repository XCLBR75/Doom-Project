using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public Animator creditsAnimator; // Reference to the Animator controlling the credits animation
    public int mainMenuSceneIndex = 0; // Build index for the main menu scene


    void Start()
    {
        // Ensure the credits animation starts immediately upon entering the scene
        if (creditsAnimator != null)
        {
            creditsAnimator.SetTrigger("StartCredits");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    // Load the main menu scene
    private void ReturnToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None; // Lock the cursor
        Cursor.visible = true; // Hide the cursor
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
