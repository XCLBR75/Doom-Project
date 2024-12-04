using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject playerUI;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
        Time.timeScale = 0f;
        playerUI.SetActive(false);
        Gun.noShoot = true;
        AudioController.instance.StopBGM();

        // Prevent MouseLook from reading the Return key
        MouseLook.shouldRead = false;
    }

    public void BackToTitle()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
