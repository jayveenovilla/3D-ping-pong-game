using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    ParticleSystem blueSmokeParticle;
    ParticleSystem rocketSmallSlow;
    private Vector3 particlePosition;

    BallMovement myBallMovement;
    // Start is called before the first frame update
    void Start()
    {
        myBallMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
        blueSmokeParticle = GameObject.Find("SmokeBlue").GetComponentInChildren<ParticleSystem>();
        if (blueSmokeParticle.isPlaying)
        {
            blueSmokeParticle.Stop();
        }

        rocketSmallSlow = GameObject.Find("RocketSmallSlow").GetComponentInChildren<ParticleSystem>();
        if (rocketSmallSlow.isPlaying)
        {
            rocketSmallSlow.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator playerSmoke()
    {
        particlePosition = myBallMovement.ballPosition;
        if (!blueSmokeParticle.isPlaying)
        {
            blueSmokeParticle.Play();
        }
        blueSmokeParticle.gameObject.transform.position = particlePosition;
        yield return new WaitForSecondsRealtime(.2f);
        if (blueSmokeParticle.isPlaying)
        {
            blueSmokeParticle.Stop();
        }
    }
    
    public IEnumerator fireworkSmall()
    {
        Debug.Log("called function fireworksmall");
        particlePosition = myBallMovement.ballPosition;
        if (!rocketSmallSlow.isPlaying)
        {
            rocketSmallSlow.Play();
        }
        rocketSmallSlow.gameObject.transform.position = particlePosition;
        yield return new WaitForSecondsRealtime(1.5f);
        if (rocketSmallSlow.isPlaying)
        {
            rocketSmallSlow.Stop();
        }
    }
}
