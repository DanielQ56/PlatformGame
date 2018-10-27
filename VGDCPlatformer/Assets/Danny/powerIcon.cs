using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerIcon : MonoBehaviour {

    GameObject power;
    SpriteRenderer powerSprite;
    SpriteRenderer playerSprite;

	// Use this for initialization
	void Start () {
        power = GameObject.FindGameObjectWithTag("powerup");
        powerSprite = power.GetComponent<SpriteRenderer>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        alignCenter();
	}

    void alignCenter()
    {
        Vector3 pVect = new Vector3(playerSprite.bounds.center.x, playerSprite.bounds.center.y + (playerSprite.bounds.size.y / (7/4)));
        powerSprite.transform.position = pVect;
    }
}
