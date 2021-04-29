using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{
    public AudioClip[] audioChoices;
    AudioSource ballAudio;
    int x;
    bool dropped = false;
    public void Start()
    {
        ballAudio = GetComponent<AudioSource>();
        x = -1;
    }
    private void OnCollisionEnter(Collision c)
    {
        if (x == -1 && dropped == false){
            dropped = true;
            return;
        }
        x = Random.Range(0,7);
        ballAudio.PlayOneShot(audioChoices[x], 0.7F);
    }

}
