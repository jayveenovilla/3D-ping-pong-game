using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highScore, bonusPoints;
    public Text scoreText, highScoreText, gameOverScoreText, bonusPointsText;
    private void Awake()
    {
        instance = this;
        score = 0;
        bonusPoints = 0;

        if (PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;
        highScoreText.text = highScore.ToString();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddScore()
    {
        score++;
        UpdateHighScore();
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }

    public void AddBonus()
    {
        bonusPoints++;
        bonusPointsText.text = bonusPoints.ToString();
    }

    public void UpdateHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
        bonusPoints = 0;
        bonusPointsText.text = bonusPoints.ToString();
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();

    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = highScore.ToString();

    }
}
