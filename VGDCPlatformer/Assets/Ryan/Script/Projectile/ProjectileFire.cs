using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour {

	public GameObject projectilePrefab;
	public GameObject player;
    private PlayerAmmo ammoControl;
	private bool parentFacingRight;
	public int ammoCount;

	// Use this for initialization
	void Start () {
		ammoControl = player.GetComponent<PlayerAmmo>();
		ammoCount = ammoControl.getCurrentAmmo();
	}
	
	// Update is called once per frame
	void Update () {

		ammoCount = ammoControl.getCurrentAmmo();

        //if (Input.GetButtonDown("Fire1")) {
        //	FireProj();
        //}
        if (Input.GetMouseButtonDown(0) && ammoCount > 0) {
			Vector2 shootDirection;
			shootDirection=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
			FireDirectedProj(shootDirection);
			ammoControl.decreaseAmmo(1);
			if (ammoCount == 0) {
				Debug.Log("No more ammo");
			}
		}
		
	}
	
	public void FireProj() { //for firing only left or right

		parentFacingRight = player.GetComponent<CharacterController2D>().m_FacingRight;
		GameObject Clone;
		Clone = (Instantiate(projectilePrefab, transform.position, transform.rotation));
        Clone.GetComponent<Projectile>().facingRight = parentFacingRight;	
	}
	
	public void FireDirectedProj(Vector3 direct) {
		GameObject Clone;
		Clone = Instantiate(projectilePrefab, transform.position, transform.rotation);
		Clone.GetComponent<Rigidbody2D>().velocity = new Vector2 (direct.x, direct.y);
		
		
	}
}
