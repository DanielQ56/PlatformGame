using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJump : MonoBehaviour {

    public string[] jumpProb;
    public float fallMultiplier;
    public float lowJumpMultipler;
    public float jumpVelocity;

    Rigidbody2D myBody;
    int chosenNum;
    bool coroutineInProgress = false;
    bool jumping = false;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        randNum();
        jump((jumpProb[chosenNum] == "jump"));
        jumpGravity(chosenNum);
    }

    void randNum()
    {
        if(!jumping)
        {
            chosenNum = (int)(Random.value * jumpProb.Length);
        }
    }

    void jump(bool shouldJump)
    {

        if (shouldJump && !jumping)
        {
            jumping = true;
            myBody.velocity += Vector2.up * jumpVelocity;
        }
    }

    void jumpGravity(int num)
    {
        if (myBody.velocity.y < 0)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (num < jumpProb.Length / 2 && myBody.velocity.y > 0)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;
        }
        if (myBody.velocity.y == 0 && !coroutineInProgress && jumping)
        {
            StartCoroutine("delayBetweenJump");
        }
    }

    IEnumerator delayBetweenJump()
    {
        float sec = Random.value * 3f;
        coroutineInProgress = true;
        yield return new WaitForSeconds(sec);
        jumping = false;
        coroutineInProgress = false;
    }
}
