using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum Difficulty { Normal, Hard }
    public Difficulty currentDifficulty = Difficulty.Normal;

    public float enemyAttackMultiplier = 1f;
    public float enemyHealthMultiplier = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        currentDifficulty = difficulty;
        enemyAttackMultiplier = difficulty == Difficulty.Normal ? 1f : 2f;
        enemyHealthMultiplier = difficulty == Difficulty.Normal ? 0f : 2f;
    }
}

