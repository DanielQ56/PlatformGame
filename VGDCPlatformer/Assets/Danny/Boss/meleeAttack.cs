using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour {
    public float waitTime = 1;
    // Use this for initialization
    GameObject player;
    GameObject boss;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
	}
	
	// Update is called once per frame
	void Update () {
        updatePosition();            
	}

    void updatePosition()
    {
        if (boss.GetComponent<BossMovement>().isFacingLeft())
        {
            transform.position = new Vector2(boss.transform.position.x - boss.GetComponent<SpriteRenderer>().bounds.size.x / 2, boss.transform.position.y);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            transform.position = new Vector2(boss.transform.position.x + boss.GetComponent<SpriteRenderer>().bounds.size.x / 2, boss.transform.position.y);
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
}
