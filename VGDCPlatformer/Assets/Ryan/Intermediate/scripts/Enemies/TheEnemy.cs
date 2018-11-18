using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	public bool moveRight = false; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
	
    //Patrol Positions
    public Transform positionA;
    public Transform positionB;

    public GameObject parent;

	
	// Update is called once per frame
	void Update () {
		
		if (moveRight == true)
		{
			transform.Translate(Vector2.right * movSpeed * Time.deltaTime);
		}

		else
		{
			transform.Translate(Vector2.left * movSpeed * Time.deltaTime);
		}

		//enemy moves until reaching a boundary, then we will flip the gameObject
		if (transform.position.x >= positionA.position.x ||
		transform.position.x < positionB.position.x) 
		{
			Flip();
		}
	}

    //Destroys the GameObject
	public void Die()
	{
		Destroy(parent);
	}

    //flips the entire gameObject and its components
    void Flip()
    {
        moveRight = !moveRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
