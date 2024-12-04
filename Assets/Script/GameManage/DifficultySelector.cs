using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public Button normalButton;
    public Button hardButton;

    public void SetNormalDifficulty()
    {
        GameManager.Instance.SetDifficulty(GameManager.Difficulty.Normal);
        normalButton.Select(); // Highlight the Normal button
    }

    public void SetHardDifficulty()
    {
        GameManager.Instance.SetDifficulty(GameManager.Difficulty.Hard);
        hardButton.Select(); // Highlight the Hard button
    }
}
