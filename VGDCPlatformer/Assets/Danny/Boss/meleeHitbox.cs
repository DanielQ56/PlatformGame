using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeHitbox : MonoBehaviour {
    public float waitTime = 5f;


    GameObject melee;
    BoxCollider2D body;
    BossAudio bA;
    bool canAttack = true;
    // Use this for initialization
    void Start () {
        body = GetComponent<BoxCollider2D>();
        melee = null;
        bA = GetComponentInParent<BossAudio>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && melee == null && canAttack)
        {
            Vector2 pos;
            float angle;
            if (GetComponentInParent<BossMovement>().isFacingLeft())
            {
                pos = new Vector2(transform.parent.position.x - GetComponentInParent<SpriteRenderer>().bounds.size.x / 2, transform.position.y);
                angle = 90f;
            }
            else
            {
                pos = new Vector2(transform.parent.position.x + GetComponentInParent<SpriteRenderer>().bounds.size.x / 2, transform.position.y);

                angle = -90f;
            }
            melee = Instantiate(GetComponentInParent<BossAttack>().meleePrefab);
            melee.transform.parent = transform;
            melee.transform.position = pos;
            melee.transform.eulerAngles = new Vector3(0, 0, angle);
            bA.kickSound();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            StartCoroutine("waitAttack");
        }
    }

    IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(melee);
        melee = null;
    }
    
    public void die()
    {
        canAttack = false;
    }
}
