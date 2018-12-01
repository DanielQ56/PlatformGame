using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialGroundRespawn : MonoBehaviour {

	private Vector3 originalPlayerPosition;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		originalPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnCollisionEnter2D(Collision2D collision)
    {
        //set the player as a child to the platform gaemObject
        //this allows movement of the player with moving platforms
        if (collision.gameObject.CompareTag("Player"))
        { 
			player.transform.position = originalPlayerPosition;
        }
    }
	
}
