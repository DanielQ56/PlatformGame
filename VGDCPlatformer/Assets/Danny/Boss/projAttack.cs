using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projAttack : MonoBehaviour {


    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collid)
    {
        if (collid.tag != "Boss" && collid.name != "meleeHitbox")
            Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
