﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField]
    private float ballSpeed;

    private Vector3 ballDirection;
    private Vector3 ballStartPosition;
    public Vector3 ballPosition;
    private Rigidbody rb;

    public GameObject Paddle;
    GameOverMenu myGameOverMenu;
    PlayerLives myPlayerLives;
    ParticleEffects myParticleEffects;

    // Start is called before the first frame update
    void Start() {
        myGameOverMenu = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverMenu>();
        Paddle = GameObject.Find("PlayerPaddle");   //attached PlayerLives script to PlayerPaddle
        myParticleEffects = GameObject.Find("ParticleEffects").GetComponent<ParticleEffects>(); ;  //attached ParticleEffects script to particleeffect object
        myPlayerLives = Paddle.GetComponent<PlayerLives>();
        rb = GetComponent<Rigidbody>();
        ballStartPosition = transform.position;         //start position of ball
        MoveBall();
    }

    // Update is called once per frame
    void FixedUpdate() {
        rb.MovePosition(transform.position + ballDirection * Time.deltaTime * ballSpeed);

        //resets position of ball to center
        if (Input.GetKeyDown(KeyCode.Space)) {
            MoveBall();
        }

    }

    private void MoveBall() {
        transform.position = ballStartPosition;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        ballDirection = new Vector3(x, 0, z).normalized;        //locks movement of ball to x and z axis only. it is based on position of our playing field
    }

    private void OnCollisionEnter(Collision other) {
        string str = other.gameObject.name;
        if (str == "Boundary Players Goal" || str == "Boundary Enemy Goal")     //check the boundary names
        {
            ballPosition = rb.gameObject.transform.position;
            StartCoroutine(myParticleEffects.blueSmoke());
            myPlayerLives.playerDecreaseLives();          //call gameover function in gameovermenu script
            if (GameManager._instance.player.playerLives > 0)
            {
                MoveBall();     //if player still has lives then move the ball back to start position
            }
        }
        
        if (str == "YellowStar")
        {
            Debug.Log("bonus tag works");
        }

        ContactPoint contact = other.GetContact(0);
        Vector3 normal = contact.normal;
        ballDirection = Vector3.Reflect(ballDirection, normal);     // Makes the reflected object appear opposite of the original object     
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Bonus")        //for use when the ball interacts with any of the stars/coins
        {
            ballPosition = c.gameObject.transform.position;
            StartCoroutine(myParticleEffects.fireworkSmall());
        }
    }
}

