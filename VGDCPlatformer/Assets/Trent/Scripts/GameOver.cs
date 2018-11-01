using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour {
    private Transform camTrans;
    private bool outsideCam;
    private float startTime;
    private float currTime;
	// Use this for initialization
	void Start () {
        camTrans = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        outsideCam = false;
        currTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float offset = Math.Abs(transform.position.x) - Math.Abs(camTrans.position.x) + 10;
		if (transform.position.y <= -6)
        {
            EndGame();
        }
        if (offset <= 0 && !outsideCam)
        {
            outsideCam = true;
            Debug.Log("Outside Cam");
            outsideCamera();
            startTime = Time.time;
        }
        else if (offset <= 0 && outsideCam)
        {
            outsideCamera();
        }
        else
        {
            outsideCam = false;
            Debug.Log("Inside Cam");
            startTime = 0;
            currTime = 0;
        }
	}
    private void outsideCamera()
    {
        currTime += Time.time - startTime;
        Debug.Log(currTime);
        if (currTime >= 500 && outsideCam)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
