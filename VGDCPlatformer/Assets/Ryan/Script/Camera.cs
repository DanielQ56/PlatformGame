using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject player;
    // Use this for initialization

    private float offset_x;
	void Start () {
        offset_x = transform.position.x - player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 new_position = transform.position;
        new_position.x = player.transform.position.x + offset_x;
        transform.position = new_position;
	}
}
