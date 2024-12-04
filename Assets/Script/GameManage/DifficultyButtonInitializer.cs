using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonInitializer : MonoBehaviour
{
    public Button normalButton;
    public Button hardButton;

    private void Start()
    {
        
        // Check current difficulty from GameManager
        if (GameManager.Instance.currentDifficulty == GameManager.Difficulty.Normal)
        {
            SetButtonHighlighted(normalButton);
        }
        else
        {
            SetButtonHighlighted(hardButton);
        }
    }

    private void SetButtonHighlighted(Button button)
    {
        // Simulate a highlight by selecting the button
        button.Select();
    }
}
