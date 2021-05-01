using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    ParticleSystem blueSmokeParticle;
    ParticleSystem rocketSmall;
    private Vector3 particlePosition;
    private Vector3 startPosition;

    BallMovement myBallMovement;
    // Start is called before the first frame update
    void Start()
    {
        myBallMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
        blueSmokeParticle = GameObject.Find("SmokeBlue").GetComponentInChildren<ParticleSystem>();  //particles are offcamera in a ParticleEffects object
        rocketSmall = GameObject.Find("RocketSmall").GetComponentInChildren<ParticleSystem>();      
        startPosition = GameObject.Find("ParticleEffects").transform.position;                  //position of ParticleEffects object for particles to stay active between uses off camera

        if (blueSmokeParticle.isPlaying)
        {
            blueSmokeParticle.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator blueSmoke()        //smoke particles plays upon player loss of life
    {
        particlePosition = myBallMovement.ballPosition;        
        if (!blueSmokeParticle.isPlaying)
        {
            blueSmokeParticle.Play();
        }
        blueSmokeParticle.gameObject.transform.position = particlePosition;     //moves to position where the ball hit player/enemy boundary
        yield return new WaitForSecondsRealtime(.2f);
        
        if (blueSmokeParticle.isPlaying)
        {
            blueSmokeParticle.Stop();
        }
    }
    
    public IEnumerator fireworkSmall()
    {
        particlePosition = myBallMovement.ballPosition;
        rocketSmall.gameObject.transform.position = particlePosition;
        yield return new WaitForSecondsRealtime(.5f);
        rocketSmall.gameObject.transform.position = startPosition;
    }
}
