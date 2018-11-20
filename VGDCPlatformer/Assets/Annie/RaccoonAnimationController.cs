using UnityEngine;
using System.Collections;


public class RaccoonAnimationController : MonoBehaviour {

	private Rigidbody2D rb;
	private CharacterController2D charControl;
	private SpriteRenderer spriteRend;
	// This is a reference to the Animator component
	private Animator anim;

	// Reference to PlayerMove
	private PlayerMove pMove;
	
	private float playerSpeed = 0f;
	private bool animFacingRight = true;

	
	// We initialize our two references in the Start method
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		charControl = GetComponent<CharacterController2D>();
		spriteRend = GetComponent<SpriteRenderer>();
		pMove = GetComponent<PlayerMove>();
		anim = GetComponent<Animator>();
		//animFacingRight = charControl.m_FacingRight;
	}


	
	// We use FixedUpdate to do all the animation work
	void FixedUpdate() {
		//GET PLAYER SPEED 
		playerSpeed = Input.GetAxisRaw("Horizontal");
		//GET PLAYER FACING RIGHT 
		//playerFacingRight = charControl.m_FacingRight;
		// The speed parameter of the Animator now knows
		// how fast the player is moving and responds accordingly
		anim.SetFloat("Speed", Mathf.Abs(playerSpeed));



	}

	void reverseImage()
	{
		animFacingRight = !animFacingRight;
		// Get and store the local scale of the RigidBody2D
		Vector2 theScale = rb.transform.localScale;
		theScale.x *= -1;
		rb.transform.localScale = theScale;
	}

}