using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlTutorial : MonoBehaviour {

	public GameObject player;
	public Transform target;
	public float panningSpeed;
	private Vector3 offset;
	private bool reachedTarget = false;
	// Use this for initialization
	void Start () {
        //offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
		if(!reachedTarget) {
			float step = panningSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), step);
		} else {
			transform.position = player.transform.position + offset;
		}
		
		if(0 <= transform.position.x - target.position.x && transform.position.x - target.position.x <= 1) { //set offset for the camera to start following player
			Debug.Log("target achieved");
			reachedTarget = true;
			offset = transform.position - player.transform.position;
		}
		
	}

    public bool targetReached()
    {
        return reachedTarget;
    }
}
