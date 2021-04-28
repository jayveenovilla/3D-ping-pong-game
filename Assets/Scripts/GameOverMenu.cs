using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public MenuController menuController;
    public GameOverMenu gameOverMenu;

    public Button restartButton;



    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu = GameObject.FindObjectOfType<GameOverMenu>();
        menuController = GameObject.FindObjectOfType<MenuController>();
        if (menuController.CheckButton("Restart Button"))       //menu controller already has main menu and quit buttons. added restart button for play scene
        {
            restartButton = GameObject.Find("Restart Button").GetComponent<Button>();
            restartButton.onClick.AddListener(() => menuController.LoadScene(2));
        }
        gameOverMenu.gameObject.SetActive(false);      //inactivates game over menu at start of playtest scene
    }

    public void GameOver()   //game over menu to be used when player runs out of lives
    {
        gameOverMenu.gameObject.SetActive(true);    //deactivates game over menu
    }

}
