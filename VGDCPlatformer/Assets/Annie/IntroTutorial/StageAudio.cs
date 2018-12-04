using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAudio : MonoBehaviour {

    AudioSource aud;
    bool started = false;
	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!started)
        {
            if(transform.parent.gameObject.GetComponent<CameraControlTutorial>().targetReached())
            {
                StartCoroutine("playMusic");
                started = true;
            }
        }
	}

    IEnumerator playMusic()
    {
        yield return new WaitForSeconds(1f);
        aud.Play();
    }
}
