using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterTrigger : MonoBehaviour {
    [Header("Powerup Settings")]
    public string PowerUp;

    [Header("Dive Animation")]
    public float diveIdleSeconds;
    public float diveUpForce = 0f;
    public float diveUpSeconds = 1;

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
            Debug.Log("Player is diving.");
            OnDumpsterInteract();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerObject) // Need to make sure only the player can trigger the animation
        { 
            Debug.Log("Player on dumpster trigger");
            playerOnDumpster = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerObject)
        {
            Debug.Log("Player left dumpster trigger");
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

        yield return new WaitForSeconds(diveIdleSeconds);

        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerSprite.color = new Color(1, 1, 1, 1);
        Debug.Log("Player can move again.");
    }

    private IEnumerator DoDiveAnimation() // Polishing this up. Not sure if it'll be implemented in the future.
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        dumpsterCollider.enabled = false;


        Debug.Log("Player is diving");

        yield return new WaitForSeconds(diveIdleSeconds);

        playerRigidBody.AddForce(new Vector3(0f, diveUpForce, 0f));
        yield return new WaitForSeconds(diveUpSeconds);
        dumpsterCollider.enabled = true;
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Debug.Log("Player can move again.");
    }




}
