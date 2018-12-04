using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projAttack : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collid)
    {
        if (collid.tag == "Player" || collid.tag == "environment")
            Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
