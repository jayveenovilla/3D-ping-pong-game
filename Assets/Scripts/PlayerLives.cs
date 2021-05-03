using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    GameOverMenu myGameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        myGameOverMenu = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverMenu>();
        GameManager._instance.player.isPlayerAlive = true;      //used for MoveBall method in ballmovement
        GameManager._instance.player.playerLives = 3;           //starts playtest scene with 3 lives
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerDecreaseLives()
    {
        GameManager._instance.player.playerLives--;     //keeping track of lives in singleton
        if(GameManager._instance.player.playerLives < 1)        //call function game over if player has no more lives
        {
            GameManager._instance.player.isPlayerAlive = false;     //used for MoveBall method in ballmovement
            myGameOverMenu.GameOver();     
        }
    }
}
