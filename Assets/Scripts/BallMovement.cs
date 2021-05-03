using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
    [SerializeField]
    private float ballSpeed;
    private float startBallSpeed;
    private int countBoundaryHit;

    bool isBallMoving;
    private Vector3 ballDirection;
    private Vector3 ballStartPosition;
    public Vector3 ballPosition;
    private Rigidbody rb;

    private GameObject Paddle;
    GameOverMenu myGameOverMenu;
    PlayerLives myPlayerLives;
    ParticleEffects myParticleEffects;
    DarkMode myDarkMode;
    BallAudio myBallAudio;

    public Text ballSpeedText;


    // Start is called before the first frame update
    void Start() {
        myDarkMode = GameObject.Find("DarkMode").GetComponent<DarkMode>();
        myGameOverMenu = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverMenu>();
        myBallAudio = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallAudio>();
        Paddle = GameObject.Find("PlayerPaddle");   //attached PlayerLives script to PlayerPaddle
        myParticleEffects = GameObject.Find("ParticleEffects").GetComponent<ParticleEffects>(); ;  //attached ParticleEffects script to particleeffect object
        myPlayerLives = Paddle.GetComponent<PlayerLives>();
        rb = GetComponent<Rigidbody>();
        ballStartPosition = transform.position;         //start position of ball
        isBallMoving = false;       //used for BallMove function to prevent spam of ball movement
        countBoundaryHit = 0;       //count boundary hits to prevent side to side issue
        startBallSpeed = ballSpeed;
        ballSpeedText.text = Mathf.Round(ballSpeed - startBallSpeed + 1).ToString();    //speed text display starts at 1
    }

    // Update is called once per frame
    void FixedUpdate() {
        rb.MovePosition(transform.position + ballDirection * Time.deltaTime * ballSpeed);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {        
            MoveBall();
        }
    }
    private void MoveBall() {
        if (!isBallMoving)      //check if ball is before launching ball. prevent spam launching while ball moving
        {
            rb.MovePosition(ballStartPosition);
            float x = Random.Range(0, 2) == 0 ? -1 : 1;       //set to -1 to launch toward player paddle
            float z = Random.Range(0, 2) == 0 ? -1 : 1;       //set to -1 to launch toward player paddle
            ballDirection = new Vector3(x, 0, z).normalized;        //locks movement of ball to x and z axis only. it is based on position of our playing field
            isBallMoving = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        string str = other.gameObject.name;
        if (str == "Boundary Players Goal" || str == "Boundary Enemy Goal")     //check the boundary names
        {
            ballSpeed = startBallSpeed;     //resets speed to starting speed once ball reaches goal
            ballSpeedText.text = Mathf.Round(ballSpeed - startBallSpeed + 1).ToString();        //speed text display starts at 1
            countBoundaryHit = 0;           //reset count boundary hits to 0 to prevent side to side issue
            ballPosition = rb.gameObject.transform.position;
            StartCoroutine(myParticleEffects.blueSmoke());
            myPlayerLives.playerDecreaseLives();          //call gameover function in gameovermenu script
            if (GameManager._instance.player.playerLives > 0)
            {
                ballStop();
            }
        }
        else if (str == "PlayerPaddle" || str == "PlayerPaddle (1)")
        {
            ballSpeed *= 1.01f;     //increase difficulty by raising speed 1% each time ball hits paddle
            ballSpeedText.text = Mathf.Round(ballSpeed - startBallSpeed + 1).ToString();        //speed text display starts at 1
            countBoundaryHit = 0;           //reset count boundary hits to 0 to prevent side to side issue
            ScoreManager.instance.AddScore();  //on paddle Collision add a point
            Vector3 paddlePosition = other.transform.position;
            Vector3 ballPosition = gameObject.transform.position;
            Vector3 delta = ballPosition - paddlePosition;      //angle ball deflects off of paddle changes depending on position paddle is hit
            Vector3 direction = delta.normalized;
            ballDirection = direction;
        }
        else
        {
            ContactPoint contact = other.GetContact(0);
            Vector3 normal = contact.normal;
            ballDirection = Vector3.Reflect(ballDirection, normal);     // Makes the reflected object appear opposite of the original object     
        }
        
        if (str == "Boundary Left" || str == "Boundary Right"){
            countBoundaryHit++;
        }

        if(countBoundaryHit > 7)        //count boundary hits to prevent side to side issue then resets ball if limit hit
        {
            ballStop();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Bonus")        //for use when the ball interacts with any of the stars/coins
        {
            ballPosition = c.gameObject.transform.position;
            StartCoroutine(myParticleEffects.fireworkSmall());
            myBallAudio.playCoinAudioClip();
        }
    }

    public void ballStop()
    {
        countBoundaryHit = 0;
        isBallMoving = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        ballDirection = new Vector3(0, 0, 0).normalized;    //resets vector to 0s for restart position so ball won't launch until MoveBall function
        transform.position = ballStartPosition;     //if player still has lives then move the ball back to start position
    }
}

