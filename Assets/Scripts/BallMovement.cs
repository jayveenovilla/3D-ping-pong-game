using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public GameManager gameManager;
    public Rigidbody rb;
    public float speed;

    void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() {
        Vector3 movement = new Vector3(0f, 0f, -1f);
        rb.velocity = speed * movement;
        //rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other) {

//        if (other.gameObject.tag == "Boundary") {
//            var spd = rb.velocity.magnitude;
//            Vector3 direction = Vector3.Reflect(rb.velocity.normalized, other.contacts[0].normal);
//            rb.velocity = direction * Mathf.Max(spd, 0f);
//            Debug.Log("Boundary");
//        } else {
            Vector3 direction = transform.position - other.transform.position;
            rb.velocity = speed * direction;
//            Debug.Log("Paddle");
//        }

        //direction += new Vector3(Random.Range(-1,1), 0f, Random.Range(-1, 1));
        

        Debug.Log(rb.velocity);
    }
}
