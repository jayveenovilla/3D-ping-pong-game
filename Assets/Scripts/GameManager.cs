﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public MenuController menuController;
    public  Text playerScoreText;

    public static GameManager _instance { get; private set; }
    private void Awake() {
        playerScoreText.text = "0";
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void ConnectMenuController() {
        menuController = GameObject.FindObjectOfType<MenuController>();
    }
}
