using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public MenuController menuController;
    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindObjectOfType<MenuController>();
        gameOverMenu.gameObject.SetActive(false);      //inactivates game over menu at start of playtest scene
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
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && SceneManager.GetActiveScene().name == "Playtest")    //for testing Game Over Menu in Playtest scene until "ball hits border" game over trigger is enabled
        {
            GameOver();
        }
    }
}
