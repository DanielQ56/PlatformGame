﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTutorialEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "projectile") {
			Debug.Log("obstacle removed :)");
			Destroy(gameObject);
		}
	}
}
