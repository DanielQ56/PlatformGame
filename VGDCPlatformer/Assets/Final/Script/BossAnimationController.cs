using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour {

	private BossMovement bossMove;
	private GameObject player;
	
	private Animator anim;
	private bool animFacingLeft;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		anim = GetComponent<Animator>();
		bossMove = GetComponent<BossMovement>();
		animFacingLeft = bossMove.isFacingLeft();
	}
	
	// Update is called once per frame
	void Update () {
		animFacingLeft = leftOfPlayer();
		anim.SetBool("facingLeft", animFacingLeft);
	}
	
	bool leftOfPlayer() {
		return (transform.position.x - player.transform.position.x > 0); 
	}
}
