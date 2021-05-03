using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public MenuController menuController;
    public GameObject gameOverMenu;
    public GameObject newHighScore;

    private GameObject ball;
    ParticleEffects myParticleEffects;
    BallAudio myBallAudio;
    BallMovement myBallMovement;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindObjectOfType<MenuController>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        gameOverMenu.gameObject.SetActive(false);      //inactivates game over menu at start of playtest scene
        newHighScore.gameObject.SetActive(false);
        myParticleEffects = GameObject.Find("ParticleEffects").GetComponent<ParticleEffects>(); ;  //attached ParticleEffects script to particleeffect object
        myBallAudio = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallAudio>();
        myBallMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
    }
    
    public void GoToPlaytest()
    {
        SceneManager.LoadScene("Playtest");     //menucontroller findobject will not find inactive buttons. used this function as onclick
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");     //menucontroller findobject will not find inactive buttons. used this function as onclick
    }

    public void Quit()
    {
        menuController.QuitGame();      //quit game function in menu controller
    }
    public void GameOver()   //game over menu to be activated when player runs out of lives
    {
        gameOverMenu.gameObject.SetActive(true);
        myBallMovement.ballStop();
        //ball.SetActive(false);      //inactivate ball on game over scenario. destroy(object) causes an error with sound but now ball sound script now has a null check
        if (GameManager._instance.player.highScore > GameManager._instance.player.previousHighScore)
        {
            newHighScore.gameObject.SetActive(true);
            myBallAudio.playLifeUpAudioClip();
            myParticleEffects.newHighScoreFireworks();         
        }
    }
    void Update()
    {

    }
}
