using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjectile : MonoBehaviour {

	public GameObject projectilePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			FireProj();
		}
	}
	
	public void FireProj() {
		GameObject Clone;
		Clone = (Instantiate(projectilePrefab, transform.position, transform.rotation));
	}
}
