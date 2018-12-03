using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour {

	private BossMovement bossMove;

	private Animator anim;
	private bool animFacingLeft;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		bossMove = GetComponent<BossMovement>();
		animFacingLeft = bossMove.isFacingLeft();
	}
	
	// Update is called once per frame
	void Update () {
		animFacingLeft = bossMove.isFacingLeft();
		anim.SetBool("facingLeft", animFacingLeft);
	}
}
