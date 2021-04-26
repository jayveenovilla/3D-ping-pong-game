using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody rb;
    public float speed;


    private void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetAxis("Horizontal") != 0) {
            MoveHorizontal();
        }
        // Commented out just in case we need this function
/*        if(Input.GetAxis("Vertical") != 0) {
            MoveForward();
        }*/
    }

    private void MoveHorizontal() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    // MoveForWard works left it in just incase we need it
/*    private void MoveForward() {
        Vector3 movement = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }*/
}
