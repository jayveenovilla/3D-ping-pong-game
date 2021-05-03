﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{
    public AudioClip[] audioChoices;
    AudioSource ballAudio;
    int x;
    bool dropped = false;

    private GameObject ball;
    public void Start()
    {
        ballAudio = GetComponent<AudioSource>();
        x = -1;
    }
    private void OnCollisionEnter(Collision c)
    {
        ball = GameObject.FindGameObjectWithTag("Ball");        //check for ball object upon collision so no sound error if ball is inactive
        if (x == -1 && dropped == false){
            dropped = true;
            return;
        }
        x = Random.Range(0,7);
        if (ball != null) {     //check if ball object is not destroyed upon game over
            ballAudio.PlayOneShot(audioChoices[x], 1.0F);
        }
    }
    public void playCoinAudioClip()
    {
        ballAudio.PlayOneShot(audioChoices[7], 0.7F);           //plays coin audio clip
    }
    public void playLifeUpAudioClip()
    {
        ballAudio.PlayOneShot(audioChoices[8], 1.0F);           //plays coin audio clip
    }
    public void playLifeLossAudioClip()
    {
        ballAudio.PlayOneShot(audioChoices[9], 1.0F);           //plays coin audio clip
    }
    public void playSquishAudioClip()
    {
        ballAudio.PlayOneShot(audioChoices[10], 1.0F);           //plays coin audio clip
    }
}
