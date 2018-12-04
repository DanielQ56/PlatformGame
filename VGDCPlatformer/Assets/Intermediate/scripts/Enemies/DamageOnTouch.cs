using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if this object touches an enemy's hurtbox
        if (collision.gameObject.tag == "hurtbox")
        {
            //to kill enemy, we call enemy script Die() function to kill object
            TheEnemy script = collision.gameObject.GetComponentInParent<TheEnemy>();
            script.Die();
        }
    }
}
