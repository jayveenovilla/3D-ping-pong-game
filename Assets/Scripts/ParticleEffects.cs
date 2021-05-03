using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    ParticleSystem blueSmokeParticle;
    ParticleSystem rocketSmallBlack;
    ParticleSystem rocketSmall;
    ParticleSystem rocketLarge0;
    ParticleSystem rocketLarge1;
    ParticleSystem rocketLarge2;
    ParticleSystem rocketLarge3;
    public ParticleSystem[] particleSystemArr;
    private Vector3 particlePosition;
    private Vector3 startPosition;

    BallMovement myBallMovement;
    // Start is called before the first frame update
    void Start()
    {
        myBallMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
        blueSmokeParticle = GameObject.Find("SmokeBlue").GetComponentInChildren<ParticleSystem>();  //particles are offcamera in a ParticleEffects object
        rocketSmallBlack = GameObject.Find("RocketSmallBlack").GetComponentInChildren<ParticleSystem>();  //particles are offcamera in a ParticleEffects object
        rocketSmall = GameObject.Find("RocketSmall").GetComponentInChildren<ParticleSystem>();
        rocketLarge0 = GameObject.Find("RocketLarge").GetComponentInChildren<ParticleSystem>();
        rocketLarge1 = GameObject.Find("RocketLarge (1)").GetComponentInChildren<ParticleSystem>();
        rocketLarge2 = GameObject.Find("RocketLarge (2)").GetComponentInChildren<ParticleSystem>();
        rocketLarge3 = GameObject.Find("RocketLarge (3)").GetComponentInChildren<ParticleSystem>();
        startPosition = GameObject.Find("ParticleEffects").transform.position;                  //position of ParticleEffects object for particles to stay active between uses off camera

        for(int i=0; i < 7; i++)
        {
            if (particleSystemArr[i].isPlaying)
            {
                particleSystemArr[i].Stop();
            }
        }
        /*
        if (blueSmokeParticle.isPlaying)
        {
            blueSmokeParticle.Stop();
        }*/
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

    public IEnumerator blackFirework()        //smoke particles plays upon player loss of life
    {
        particlePosition = myBallMovement.ballPosition;
        rocketSmallBlack.gameObject.transform.position = particlePosition;
        yield return new WaitForSecondsRealtime(.5f);
        rocketSmallBlack.gameObject.transform.position = startPosition;
    }

    public IEnumerator blackFirework(Transform pos)        //smoke particles plays upon player loss of life
    {
        rocketSmallBlack.gameObject.transform.position = pos.position;
        yield return new WaitForSecondsRealtime(.5f);
        rocketSmallBlack.gameObject.transform.position = startPosition;
    }
    public IEnumerator fireworkSmall()
    {
        particlePosition = myBallMovement.ballPosition;
        rocketSmall.gameObject.transform.position = particlePosition;
        yield return new WaitForSecondsRealtime(.5f);
        rocketSmall.gameObject.transform.position = startPosition;
    }

    public void newHighScoreFireworks()
    {
        for (int i = 1; i < 5; i++)
        {
            particleSystemArr[i].Play();
        }
    }
    public IEnumerator newLifeFireworks()
    {
        particleSystemArr[5].Play();
        particleSystemArr[6].Play();
        yield return new WaitForSecondsRealtime(3.0f);
        particleSystemArr[5].Stop();
        particleSystemArr[6].Stop();

    }
}
