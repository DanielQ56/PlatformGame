using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

	public float BottomKillBoundary = -15f;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
		if (is_below_bottomKillBoundary()){
			player.GetComponent<PlayerHealth>().killPlayer();
		}
	}

	bool is_below_bottomKillBoundary() {
		return player.transform.position.y < BottomKillBoundary;
	}
}
