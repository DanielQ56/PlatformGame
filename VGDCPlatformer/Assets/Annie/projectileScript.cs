using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	public float velX = 5f;
	float velY = 0f;
	Rigidbody2D rb;	
	public bool facingRight;
	
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//if(facingRight) {
		//	rb.velocity = new Vector2(velX, velY);
		//} else {
		//	rb.velocity = new Vector2(-velX, velY);
		//}
		
	}
	
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
