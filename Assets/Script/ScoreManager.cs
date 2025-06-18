using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score = 0;

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        UpdateUI();

    }
    void UpdateUI()
    {
        if (scoreText != null)
        scoreText.text= "Score: " + score;
    }


}


