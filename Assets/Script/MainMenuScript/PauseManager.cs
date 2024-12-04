using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Drag the PauseMenu panel object here
    public GameObject playerUI;
    private bool isPaused = false;

    public void BackToTitle()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(0);
    }

    void Update()
    {
        // Check for ESC key press to toggle pause
        if (!isPaused && Input.GetKeyDown(KeyCode.Return))
        {
            TogglePause();
        }
    }

    // Toggles the pause state
    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Pauses the game and shows the PauseMenu
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Stops the game time (pauses everything)
        pauseMenu.SetActive(true);
        playerUI.SetActive(false);
        Gun.noShoot = true;

        // Prevent MouseLook from reading the Return key
        MouseLook.shouldRead = false;

    }

    // Resumes the game and hides the PauseMenu
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerUI.SetActive(true);
        isPaused = false;
        Time.timeScale = 1f; // Resumes the game time (unpauses everything)

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor

        // Allow MouseLook to read the Return key again
        MouseLook.shouldRead = true;
        MouseLook.isCursorLocked = true;
        Gun.noShoot = false;
    }
    

}
