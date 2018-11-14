using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float camSpeed = 0f;
    private GameObject player;
    private float offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        offset = player.transform.position.y - transform.position.y;
        transform.position += new Vector3(camSpeed / 100, offset, 0f);
	}
}
