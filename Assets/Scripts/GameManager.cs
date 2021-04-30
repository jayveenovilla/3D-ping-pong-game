using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class GameManager : MonoBehaviour {

    public MenuController menuController;
    public class Player
    {
        public int highScore;      //current high score
        public int currentScore;      //current score
        public int playerLives;     //player lives
        public string playerName ;   //player name to be displayed on HUD or game over screen with a high score
        public bool isPlayerAlive;      //not sure if bool is needed. just in case
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
}
