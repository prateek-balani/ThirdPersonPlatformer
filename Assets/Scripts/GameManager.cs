using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        // Ensure a single instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("scoreText: " + scoreText);

        
        if (scoreText)
        {
            scoreText.text = "Score: " + score;
            Debug.Log("scoreText updated");
            UpdateScoreUI(); // Only update UI if scoreText is valid
        }
        else
        {
            Debug.LogWarning("ScoreText is missing or has been destroyed.");
        }
    }

    private void UpdateScoreUI()
    {
        // Ensure scoreText is still valid before updating
        if (scoreText)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
