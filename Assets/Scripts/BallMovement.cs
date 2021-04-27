using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField]
    private float ballSpeed;

    private Vector3 ballDirection;
    private Vector3 ballStartPosition;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
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

        Debug.Log(ballDirection);
    }

    private void MoveBall() {
        transform.position = ballStartPosition;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        ballDirection = new Vector3(x, 0, z).normalized;        //locks movement of ball to x and z axis only. it is based on position of our playing field
    }

    private void OnCollisionEnter(Collision other) {
        ContactPoint contact = other.GetContact(0);
        Vector3 normal = contact.normal;
        ballDirection = Vector3.Reflect(ballDirection, normal);     // Makes the reflected object appear opposite of the original object
        
    }
}

