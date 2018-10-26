using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterTrigger : MonoBehaviour {
    public float diveAnimationSeconds;

    // MAKE SURE PLAYER OBJECT HAS "Player" TAG!
    private GameObject playerObject;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSprite;
    private bool playerOnDumpster;

    private BoxCollider2D dumpsterCollider;


    void GetPlayerComponents(GameObject playerObject)
    {
        playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
        playerSprite = playerObject.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        GetPlayerComponents(playerObject);

        dumpsterCollider = GetComponent<BoxCollider2D>(); // For DoDiveAnimation()
	}

    private void FixedUpdate()
    {
        if (playerOnDumpster && Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0) // Button is currently "s"
        { 
            Debug.Log("Player interacted with dumpster.");
            OnDumpsterInteract();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // Need to make sure only the player can trigger the animation
        { 
            Debug.Log("Player jumped onto dumpster!");
            playerOnDumpster = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player left dumpster");
            playerOnDumpster = false;
        }
    }

    private void OnDumpsterInteract()
    {
        StartCoroutine(FreezeAndDisappear());
        StopCoroutine(FreezeAndDisappear());
        givePowerUp();   
    }

    private void givePowerUp() // Placeholder for now 
    {

    }

    private IEnumerator FreezeAndDisappear() // Current animation upon "diving" into dumpster; may be replaced by DoDiveAnimation later
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Color colorBackup = playerSprite.color;
        playerSprite.color = new Color(0, 0, 0, 0);
        Debug.Log("Player is now frozen");

        yield return new WaitForSeconds(diveAnimationSeconds);

        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerSprite.color = new Color(1, 1, 1, 1);
        Debug.Log("Player can move again.");
    }




    private IEnumerator DoDiveAnimation() // Polishing this up. Not sure if it'll be implemented in the future.
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




}
