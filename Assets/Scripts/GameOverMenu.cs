using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public MenuController menuController;
    public GameObject gameOverMenu;
    public GameObject newHighScore;

    private GameObject ball;
    ParticleEffects myParticleEffects;
    BallAudio myBallAudio;
    BallMovement myBallMovement;
    public Text newHighScoreText;

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
        myBallMovement.ballStop();      //stop ball and reset to center on game over scenario. destroy(object) or inactive causes an error with sound
        if (GameManager._instance.player.highScore > GameManager._instance.player.previousHighScore)
        {          
            StartCoroutine(FlashText());        //flashes 'New High' in game over menu
            myBallAudio.playLifeUpAudioClip();
            myParticleEffects.newHighScoreFireworks();         //uses 4 large fireworks around playfield on game over menu with new high score
        }
    }
    void Update()
    {

    }

    public IEnumerator FlashText()
    {
        bool flag = true;
        newHighScore.gameObject.SetActive(flag);                    //activate high score text
        while (GameManager._instance.player.isPlayerAlive == false)
        { //keep looping until player is alive again
            flag = !flag;                               //flip the active state of new high score text
            newHighScore.gameObject.SetActive(flag); 
            yield return new WaitForSeconds(.5f);// wait .5 seconds
        }
        newHighScore.gameObject.SetActive(false); // Don't forget to flip it back off incase it was off when exiting the loop!
    }
}
