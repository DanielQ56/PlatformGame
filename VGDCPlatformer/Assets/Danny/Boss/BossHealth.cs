using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public int maxHealth;
    public AudioClip[] audioClips;

    int currHealth;
    AudioSource aud;
	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (currHealth == 0)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D collid)
    {
        if(collid.tag == "projectile")
        {
            gotHit();
        }
    }

    void gotHit()
    {
        currHealth -= 1;
        aud.Play();
    }

    public void hit()
    {
        gotHit();
    }
}
