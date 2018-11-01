using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float camSpeed = 0f;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(camSpeed / 100, 0f, 0f);
	}
}
