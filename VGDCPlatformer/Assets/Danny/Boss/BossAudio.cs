using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour {
    public AudioClip throwNet;
    public AudioClip kick;
    public AudioClip ouch;
    public AudioClip[] hurt;
    //public AudioClip jump;
    public AudioClip death;
    public AudioClip warp;
    // Use this for initialization
    AudioSource aud;
    int hurtState = 0;
    void Start () {
        aud = GetComponent<AudioSource>();
   
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void jumpSound()
    {
        //aud.clip = jump;
        //aud.Play();
    }

    public void warpSound()
    {
        aud.clip = warp;
        aud.Play();
    }

    public void deathSound()
    {
        aud.clip = death;
        aud.Play();
    }

    public void hurtNoise(int health)
    {
        if(health == 0)
        {
            aud.clip = death;
        }
        else if (health % 5 == 0)
        {
            aud.clip = hurt[hurtState];
            hurtState += 1;
        }
        else
            aud.clip = ouch;
        aud.Play();
    }

    public void kickSound()
    {
        aud.clip = kick;
        aud.Play();
    }

    public void throwNetSound()
    {
        aud.clip = throwNet;
        aud.Play();
    }
}
