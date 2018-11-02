using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjectile : MonoBehaviour {

	public GameObject projectilePrefab;
	private GameObject player;
	private bool parentFacingRight;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetButtonDown("Fire1")) {
		//	FireProj();
		//}
		if (Input.GetMouseButtonDown(0)) {
			Vector2 shootDirection;
			shootDirection=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
			FireDirectedProj(shootDirection);
		}
		
	}
	
	public void FireProj() { //for firing only left or right
		parentFacingRight = player.GetComponent<CharacterController2D>().m_FacingRight;
		GameObject Clone;
		Clone = (Instantiate(projectilePrefab, transform.position, transform.rotation));
		Clone.GetComponent<projectileScript>().facingRight = parentFacingRight;
	}
	
	public void FireDirectedProj(Vector3 direct) {
		GameObject Clone;
		Clone = Instantiate(projectilePrefab, transform.position, transform.rotation);
		Clone.GetComponent<Rigidbody2D>().velocity = new Vector2 (direct.x, direct.y);
		
	}
}
