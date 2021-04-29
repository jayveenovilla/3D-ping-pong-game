using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public MenuController menuController;
    public GameObject pauseMenu;
    bool isGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindObjectOfType<MenuController>();
        pauseMenu.gameObject.SetActive(false);      //inactivates game over menu at start of playtest scene
        isGamePaused = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");     //menucontroller findobject will not find inactive buttons. used this function as onclick
    }

    public void Quit()
    {
        menuController.QuitGame();      //quit game function in menu controller
    }

    public void Pause()   //game over menu to be activated when player runs out of lives
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;

    }

    public void Resume()   //game over menu to be activated when player runs out of lives
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Playtest")    //for testing Game Over Menu in Playtest scene until "ball hits border" game over trigger is enabled
        {
            if (!isGamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
}
