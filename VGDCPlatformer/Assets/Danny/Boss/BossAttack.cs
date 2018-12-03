using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {
    public string[] attackProbs;
    public float waitTime = 4f;
    public float speedMulti = 1.5f;
    public GameObject projPrefab;
    public GameObject meleePrefab;


    bool waiting = false;
    SpriteRenderer sprite;
    GameObject player;  
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(!waiting)
        {
            StartCoroutine("cooldown");
        }
	}


    void rangedAttack()
    {
        if(GameObject.Find("BossProjectile") == null)
        {
            GameObject Clone;
            Vector2 pos;
            if (GetComponent<BossMovement>().isFacingLeft())
                pos = new Vector2( transform.position.x - sprite.bounds.size.x / 2, transform.position.y);
            else
                pos = new Vector2(transform.position.x + sprite.bounds.size.x / 2, transform.position.y);
            Clone = Instantiate(projPrefab, pos, transform.rotation);
            Clone.GetComponent<Rigidbody2D>().velocity = new Vector2((player.transform.position.x - transform.position.x) * speedMulti, (player.transform.position.y-transform.position.y) * speedMulti);
        }
    }

    IEnumerator cooldown()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        waiting = false;
        attack();
    }

    void attack()
    {
        int num = (int)(Random.value * attackProbs.Length);
        if(attackProbs[num] == "ranged")
            rangedAttack();
    }
}
