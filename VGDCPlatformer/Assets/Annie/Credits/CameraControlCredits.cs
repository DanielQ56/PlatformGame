using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlCredits : MonoBehaviour {

	public GameObject player;
	public Transform target;
	private Vector3 offset;

	// Use this for initialization
	void Start () {	
		//offset = transform.position.y - player.transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//transform.position.y = player.transform.position.y + offset;
		transform.position = new Vector3(transform.position.x, target.position.y, -10);
	}
}
