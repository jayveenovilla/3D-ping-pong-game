using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public MenuController menuController;
    public GameObject pauseMenu;

    GameObject gameOverParent;
    Transform gameOverChild;

    public GameObject resumeButton;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindObjectOfType<MenuController>();
        gameOverParent = GameObject.FindGameObjectWithTag("GameOver");          //find gameover object as the parent
        gameOverChild = gameOverParent.transform.Find("GameOverMenu");          //gameovermenu is intially inactive. find child of gameoverobject and save as transform
        pauseMenu.gameObject.SetActive(false);      //inactivates game over menu at start of playtest scene
        GameManager._instance.player.isGamePaused = false;
    }

    public void GoToMenu()
    {
        GameManager._instance.player.isGamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");     //menucontroller findobject will not find inactive buttons. used this function as onclick
    }

    public void Quit()
    {
        menuController.QuitGame();      //quit game function in menu controller
    }

    public void Pause()   //game over menu to be activated when player runs out of lives
    {
        pauseMenu.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);    //clear selected object
        EventSystem.current.SetSelectedGameObject(resumeButton);        //resumeButton is first selected button
        Time.timeScale = 0f;
        GameManager._instance.player.isGamePaused = true;
    }

    public void Resume()   //game over menu to be activated when player runs out of lives
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameManager._instance.player.isGamePaused = false;
    }
    void Update()
    {
        //added "is gameobject active" check to prevent Pause menu from being activated during Game Over Menu
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7")) && SceneManager.GetActiveScene().name == "Playtest" && !gameOverChild.gameObject.activeSelf)    //xbox 'start' button to be use along with 'esc' key for pause menu
        {
            if (GameManager._instance.player.isGamePaused == false)
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
