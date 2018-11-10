using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterTrigger : MonoBehaviour {
    [Header("Powerup Settings")]
    public string PowerUp;
    public string ammoOrPowerUp; // values are: "ammo" & "powerup"

    [Header("Dive Animation")]
    public float diveIdleSeconds;
    public float diveUpForce = 0f;
    public float diveUpSeconds = 1;

    // MAKE SURE PLAYER OBJECT HAS "Player" TAG!
    private GameObject playerObject;
    private Rigidbody2D playerRigidBody;
    private bool playerOnDumpster;

    private bool dumpsterUsed = false;
    private BoxCollider2D dumpsterCollider;

    void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
        dumpsterCollider = GetComponent<BoxCollider2D>(); // For DoDiveAnimation()
	}

    private void FixedUpdate()
    {
        if (playerOnDumpster && Input.GetButtonDown("Vertical") && !dumpsterUsed && Input.GetAxisRaw("Vertical") < 0) // Button is currently "s"
        { 
            OnDumpsterInteract();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerObject) // Need to make sure only the player can trigger the animation
        { 
            playerOnDumpster = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerObject)
        {
            playerOnDumpster = false;
        }
    }

    private void OnDumpsterInteract()
    {
        if (!dumpsterUsed) {
            dumpsterUsed = true;
            StartCoroutine(DoDiveAnimation());
            StopCoroutine(DoDiveAnimation());
        } else {
            Debug.Log("Dumpster has been used already!");
        }
    }

    private void givePlayerEffect() {    
        if (ammoOrPowerUp == "powerup") {
            Debug.Log("Giving player a powerup");
            givePowerUp();
        } else if (ammoOrPowerUp == "ammo") {
            Debug.Log("Giving player ammo");
            playerObject.GetComponent<playerAmmo>().giveDumpsterAmmo();
        }
    }

    private void givePowerUp() 
    {
        this.GetComponent<Powerups>().givePowerUp();
    }

    private IEnumerator DoDiveAnimation() // Full diving animation.
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        dumpsterCollider.enabled = false;

        yield return new WaitForSeconds(diveIdleSeconds);

        playerRigidBody.AddForce(new Vector3(0f, diveUpForce, 0f));
        givePlayerEffect();
        yield return new WaitForSeconds(diveUpSeconds);
        dumpsterCollider.enabled = true;
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
