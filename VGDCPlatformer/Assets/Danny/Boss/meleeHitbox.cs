using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeHitbox : MonoBehaviour {

    GameObject melee;
    BoxCollider2D body;
    // Use this for initialization
    void Start () {
        body = GetComponent<BoxCollider2D>();
        melee = null;
    }
	
	// Update is called once per frame
	void Update () {
		if(GetComponentInParent<BossMovement>().isFacingLeft())
        {
            body.offset = new Vector2(-0.5f, body.offset.y);
        }
        else
        {
            body.offset = new Vector2(0.5f, body.offset.y);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && melee == null)
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
                angle = 90f;
            }
            melee = Instantiate(GetComponentInParent<BossAttack>().meleePrefab);
            melee.transform.position = pos;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(melee);
            melee = null;
        }
    }
}
