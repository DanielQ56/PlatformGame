using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour {
    private Camera cam;
    private bool outsideCam;
    private float startTime;
    private float currTime;
	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        outsideCam = false;
        currTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
		if (transform.position.y <= -6)
        {
            EndGame();
        }
        if (viewPos.x <= 0 && !outsideCam)
        {
            outsideCam = true;
            Debug.Log("Outside Cam");
            outsideCamera();
            startTime = Time.time;
        }
        else if (viewPos.x <= 0 && outsideCam)
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
