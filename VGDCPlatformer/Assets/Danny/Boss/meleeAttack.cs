using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour {
    public float waitTime = 1f;
    // Use this for initialization
    GameObject player;
    BossMovement boss;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = transform.parent.GetComponent<BossMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        updatePosition();            
	}

    void updatePosition()
    {
        if (transform.GetComponentInParent<BossMovement>().isFacingLeft())
        {
            GetComponent<SpriteRenderer>().flipX= false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
