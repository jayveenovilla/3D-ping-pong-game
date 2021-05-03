using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[SerializeField]
public class GameManager : MonoBehaviour {

    public MenuController menuController;
    int sceneBuildIndex;
    public AudioClip[] musicChoices;
    AudioSource music;
    public class Player
    {
        public int highScore;      //current high score
        public int previousHighScore;   //previous high score
        public int currentScore;      //current score
        public int playerLives;     //player lives
        public string playerName ;   //player name to be displayed on HUD or game over screen with a high score
        public bool isPlayerAlive;      //not sure if bool is needed. just in case
        public int penaltyCount;
        public bool isGamePaused;
    }

    public Player player;
    public static GameManager _instance { get; private set; }
    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            player = new Player();          //added new player instance
        } else {
            Destroy(gameObject);
        }
    }

    public void ConnectMenuController() {
        menuController = GameObject.FindObjectOfType<MenuController>();
    }
    public void playMusic()
    {
        GameManager._instance.music = GetComponent<AudioSource>();      //locate singelton audio source
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;     //get active scene number
        if (sceneBuildIndex == 0)
        {
            if (GameManager._instance.music.clip != musicChoices[0])       //if in menu scene check if proper song is play else stop the song, change song, and play proper song
            {
                GameManager._instance.music.Stop();
                GameManager._instance.music.clip = musicChoices[0];     //selects happy upbeat song
                GameManager._instance.music.volume = 0.5f;
                GameManager._instance.music.Play();
            }
        }

        if (sceneBuildIndex == 2)
        {
            if (GameManager._instance.music.clip != musicChoices[1])    //if in play scene check if proper song is play else stop the song, change song, and play proper song
            {
                GameManager._instance.music.Stop();
                GameManager._instance.music.clip = musicChoices[1];     //selects ukelele song
                GameManager._instance.music.volume = 0.5f;
                GameManager._instance.music.Play();
            }
        }
    }
}
