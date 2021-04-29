using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highScore;
    public Text scoreText, highScoreText, gameOverScoreText;
    private void Awake()
    {
        instance = this;

        if(PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
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
