using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterTrigger : MonoBehaviour {
    public GameObject playerObject;
    public float diveAnimationSeconds;

    private bool playerOnDumpster;
    private bool playerFrozen;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.gameObject == playerObject)
        { //Need to make sure only the player can trigger the animation
            Debug.Log("Player jumped onto dumpster!");
            playerOnDumpster = true;

        }
    }

    private void FixedUpdate()
    {
        if (playerOnDumpster && Input.GetButtonDown("Interact")) { // Interact button is currently "e"
            Debug.Log("Player interacted with  dumpster.");
            DumpsterDive();
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.gameObject == playerObject)
        {
            Debug.Log("Player left dumpster");
            playerOnDumpster = false;
        }
    }

    private void DumpsterDive()
    {
        
        StartCoroutine(FreezeTimer());
        StopCoroutine(FreezeTimer());        
    }

    IEnumerator FreezeTimer()
    {
        playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Color temp = playerObject.GetComponent<SpriteRenderer>().color;
        playerObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        Debug.Log("Player is now frozen");
        yield return new WaitForSeconds(diveAnimationSeconds);
        playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        playerObject.GetComponent<SpriteRenderer>().color = temp;
        Debug.Log("Player can move again.");
    }


}
