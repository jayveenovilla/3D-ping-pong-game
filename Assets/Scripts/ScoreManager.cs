using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highScore, bonusPoints, lives;
    public Text scoreText, highScoreText, gameOverScoreText, bonusPointsText,livesText;

    BallAudio myBallAudio;
    ParticleEffects myParticleEffects;
    private void Awake()
    {
        instance = this;
        score = 0;
        bonusPoints = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            GameManager._instance.player.previousHighScore = highScore;
        }
        else
            highScore = 0;
        highScoreText.text = highScore.ToString();

    }
    void Start()
    {
        myBallAudio = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallAudio>();
        myParticleEffects = GameObject.Find("ParticleEffects").GetComponent<ParticleEffects>(); ;  //attached ParticleEffects script to particleeffect object
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
            myBallAudio.playLifeUpAudioClip();
            StartCoroutine(myParticleEffects.newLifeFireworks());
            ResetBonus();
        }
    }

    public void UpdateHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
            GameManager._instance.player.highScore = highScore;
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
        GameManager._instance.player.previousHighScore = highScore;
        highScoreText.text = highScore.ToString();

    }
}
