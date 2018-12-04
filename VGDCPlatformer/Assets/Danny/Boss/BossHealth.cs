using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public int maxHealth;
    public float deathTimer = 2f;
    public float invTime = 0.5f;
    public BossDuplicate bD;
    BossAudio bA;
    public int currHealth;
    bool invincible = false;
    bool dead = false;
	// Use this for initialization
	void Start () {
        currHealth = maxHealth;
        bA = GetComponent<BossAudio>();
        bD = gameObject.GetComponent<BossDuplicate>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currHealth == 0)
        {
            StartCoroutine("die");
        }
    }

    void OnTriggerEnter2D(Collider2D collid)
    {
        if(collid.tag == "projectile")
        {
            gotHit();
        }
    }

    void gotHit()
    {
        if (!invincible && !dead)
        {
            currHealth -= 1;
            bA.hurtNoise(currHealth);
            StartCoroutine("invincibility");
            bD.ResetTime();
            Debug.Log(currHealth);
        }
    }

    public void hit()
    {
        gotHit();
    }
    

    IEnumerator die()
    {
        dead = true;
        GetComponent<BossMovement>().die();
        GetComponent<BossJump>().die();
        GetComponentInChildren<meleeHitbox>().die();
        GetComponent<BossWarp>().die();
        GetComponent<BossAttack>().die();
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }

    IEnumerator invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(invTime);
        invincible = false;
    }

}
