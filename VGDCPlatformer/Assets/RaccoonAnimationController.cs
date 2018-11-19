using UnityEngine;
using System.Collections;


public class RaccoonAnimationController : MonoBehaviour {

	private bool facingRight = true;

	// This will be a reference to the RigidBody2D 
	// component in the Player object
	private Rigidbody2D rb;

	// This is a reference to the Animator component
	private Animator anim;


	// We initialize our two references in the Start method
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// We use FixedUpdate to do all the animation work
	void FixedUpdate() {

		// Get the extent to which the player is currently pressing left or right
		float h = Input.GetAxis("Horizontal");

		//get facingRight from characterController2D
		
		// Pass in the current velocity of the RigidBody2D
		// The speed parameter of the Animator now knows
		// how fast the player is moving and responds accordingly
		anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


		// Check which way the player is facing 
		// and call reverseImage if neccessary
		if (h < 0 && !facingRight)
			reverseImage();
		else if (h > 0 && facingRight)
			reverseImage();

	}

	void reverseImage()
	{
		// Switch the value of the Boolean
		facingRight = !facingRight;

		// Get and store the local scale of the RigidBody2D
		Vector2 theScale = rb.transform.localScale;

		// Flip it around the other way
		theScale.x *= -1;
		rb.transform.localScale = theScale;
	}

}