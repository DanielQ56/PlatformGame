﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterTrigger : MonoBehaviour {
    public GameObject playerObject;
    public float diveAnimationSeconds;
    public BoxCollider2D dumpsterCollider;

    private bool playerOnDumpster;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSprite;

    // Use this for initialization
    void Start () {
        playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
        playerSprite = playerObject.GetComponent<SpriteRenderer>();

        dumpsterCollider = GetComponent<BoxCollider2D>();
	}

    private void FixedUpdate()
    {
        if (playerOnDumpster && Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0) { // Interact button is currently "e"
            Debug.Log("Player interacted with dumpster.");
            OnDumpsterInteract();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == playerRigidBody)
        { //Need to make sure only the player can trigger the animation
            Debug.Log("Player jumped onto dumpster!");
            playerOnDumpster = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == playerRigidBody)
        {
            Debug.Log("Player left dumpster");
            playerOnDumpster = false;
        }
    }

    private void OnDumpsterInteract()
    {
        StartCoroutine(FreezeAndDisappear());
        StopCoroutine(FreezeAndDisappear());        
    }

    private IEnumerator DoDiveAnimation()
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        Vector3 oldPlayerLocation = playerObject.transform.position;
        dumpsterCollider.enabled = false;
        Debug.Log("Player is now in dumpster");

        yield return new WaitForSeconds(diveAnimationSeconds);

        dumpsterCollider.enabled = true;
        playerObject.transform.position = oldPlayerLocation;
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Debug.Log("Player can move again.");
    }

    private IEnumerator FreezeAndDisappear() // Old animation upon interacting with dumpster
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Color colorBackup = playerObject.GetComponent<SpriteRenderer>().color;
        playerSprite.color = new Color(0, 0, 0, 0);
        Debug.Log("Player is now frozen");

        yield return new WaitForSeconds(diveAnimationSeconds);

        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerSprite.color = new Color(1, 1, 1, 1);
        Debug.Log("Player can move again.");
    }


}
