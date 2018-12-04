using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float velX = 5f;
	public bool facingRight;
	
	

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		//if(facingRight) {
		//	rb.velocity = new Vector2(velX, velY);
		//} else {
		//	rb.velocity = new Vector2(-velX, velY);
		//}
		
	}
	
	void OnTriggerEnter2D(Collider2D collide) {
		if(collide.tag == "hitbox" || collide.tag == "hurtbox") {
            collide.gameObject.GetComponentInParent<Enemy>().Die();
            OnBecameInvisible();
        } 
		
		if(collide.tag != "Player" && collide.tag != "CameraBounds") {
			Destroy(gameObject);
		}
		
	}
	
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
