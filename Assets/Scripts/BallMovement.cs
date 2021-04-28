using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody rb;
    public float speed = 1f;


    private void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerBall();
    }
    void FixedUpdate() {
    }

    void playerBall()
    {
        int r = Random.Range(0,2);
        if (r == 0)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -18f);
        }
        else if (r == 1)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 18f);
        }
    }
}
