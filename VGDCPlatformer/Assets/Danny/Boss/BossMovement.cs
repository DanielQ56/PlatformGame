using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {
    public LayerMask myMask;
    public float m_speed;
    public float distanceToTravel;

    float distanceTraveled;
    Vector2 lastPos;
    Rigidbody2D myBody;
    Transform myTrans;
    SpriteRenderer mySprite;
    bool facingLeft = true;

    // Use this for initialization
    void Start () {
        distanceTraveled = 0;
        mySprite = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        myTrans = transform;
        lastPos = transform.position;
        myBody.velocity = new Vector2(-myTrans.right.x * m_speed, myBody.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {
        flipSpriteDirection();
	}

    void FixedUpdate()
    {
        checkVelocity();
        if(!isInBounds())
        {
            changeMoveDirection();
        }
        distanceTraveled += Vector2.Distance(new Vector2(myTrans.position.x, lastPos.y), lastPos);
        lastPos = new Vector2(myTrans.position.x, lastPos.y);
    }

    void checkVelocity()
    {
        if(Mathf.Abs(myBody.velocity.x) != Mathf.Abs(m_speed))
        {
            myBody.velocity = new Vector2(-myTrans.right.x * m_speed, myBody.velocity.y);
        }
    }

    void flipSpriteDirection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x > myTrans.position.x)
        {
            mySprite.flipX = true;
            facingLeft = false;
        }
        else
        {
            mySprite.flipX = false;
            facingLeft = true;
        }
        
    }

    bool isInBounds()
    {
        Debug.DrawLine(myTrans.position, myTrans.position + Vector3.down * (myTrans.position.y - lastPos.y + mySprite.bounds.size.y / 2));
        return Physics2D.Linecast(myTrans.position, myTrans.position + Vector3.down * (myTrans.position.y - lastPos.y + mySprite.bounds.size.y / 2), myMask) && !(Mathf.Abs(distanceTraveled) > distanceToTravel);
    }

    void changeMoveDirection()
    {
        m_speed *= -1;
        distanceTraveled *= -1;
        myBody.velocity = new Vector2(-myTrans.right.x * m_speed, myBody.velocity.y);
        getBackInBounds();
    }

    void getBackInBounds()
    {
        while (!isInBounds())
        {
            myTrans.Translate(myBody.velocity * Time.deltaTime);
            distanceTraveled += Vector2.Distance(new Vector2(myTrans.position.x, lastPos.y), lastPos);
            lastPos = new Vector2(myTrans.position.x, lastPos.y);
        }
    }

    public void warped(GameObject checkpoint)
    {
        myTrans.position = new Vector2(checkpoint.transform.position.x, checkpoint.transform.position.y + mySprite.bounds.size.y/2);
        lastPos = myTrans.position;
        distanceTraveled = 0;
    }

    public bool isFacingLeft()
    {
        return facingLeft;
    }
}
