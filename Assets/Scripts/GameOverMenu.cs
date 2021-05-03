using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour
{
    public MenuController menuController;
    public GameObject gameOverMenu;

    public GameObject restartButton;

    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindObjectOfType<MenuController>();
        ball = GameObject.FindGameObjectWithTag("Ball");
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
        EventSystem.current.SetSelectedGameObject(null);    //clear selected object
        EventSystem.current.SetSelectedGameObject(restartButton);       //restartButton is first selected button
        ball.SetActive(false);      //inactivate ball on game over scenario. destroy(object) causes an error with sound but now ball sound script now has a null check
    }
    void Update()
    {

    }
}
