using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameManager gameManager;
    public Button playButton, creditsButton, quitButton;

    private void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.ConnectMenuController();

        if (CheckButton("Play Button")) {
            playButton = GameObject.Find("Play Button").GetComponent<Button>();
            Debug.Log("Play button");
            //playButton.onClick.AddListener(() => LoadScene(4));
        }

        if (CheckButton("Credits Button")) {
            creditsButton = GameObject.Find("Credits Button").GetComponent<Button>();
            Debug.Log("Credits Button");
            //creditsButton.onClick.AddListener(() => LoadScene(2));
        }

        if (CheckButton("Quit Button")) {
            quitButton = GameObject.Find("Quit Button").GetComponent<Button>();
            quitButton.onClick.AddListener(() => QuitGame());
        }

    }

    public bool CheckButton(string str) {
        return !(GameObject.Find(str) == null);
    }
    public void LoadScene(int sceneNumber) {
        SceneManager.LoadScene(sceneNumber);
    }

    public void QuitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
