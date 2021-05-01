using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highScore, bonusPoints, lives;
    public Text scoreText, highScoreText, gameOverScoreText, bonusPointsText,livesText;
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
        lives = GameManager._instance.player.playerLives;
        livesText.text = lives.ToString();
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

        if(bonusPoints >= 5)//once the player gets 5 bonus, gets extra life
        {
            GameManager._instance.player.playerLives++;
            ResetBonus();
        }
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
    public void ResetBonus()
    {
        bonusPoints = 0;
        bonusPointsText.text = bonusPoints.ToString();
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = highScore.ToString();

    }
}
