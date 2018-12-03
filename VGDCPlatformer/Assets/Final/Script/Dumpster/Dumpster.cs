using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    [Header("Powerup Settings")]
    public string PowerUp;
    public string ammoOrPowerUp; // values are: "ammo" & "powerup"

    [Header("Dive Animation")]
    public float diveIdleSeconds;
    public float diveUpForce = 0f;
    public float diveUpSeconds = 0;

    // MAKE SURE PLAYER OBJECT HAS "Player" TAG!
    private GameObject playerObject;
    private Rigidbody2D playerRigidBody;
    private bool playerOnDumpster;
    private PlayerPower playerPower;

    private bool dumpsterUsed = false;
    private BoxCollider2D dumpsterCollider;

    private AudioSource OnTouchSound;

    void Start()
    {
        dumpsterCollider = GetComponent<BoxCollider2D>(); // For DoDiveAnimation()
        OnTouchSound = GetComponentInChildren<AudioSource>();
        
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
        //if (collision.gameObject == playerObject) // Need to make sure only the player can trigger the animation
        //{
        //    playerOnDumpster = true;
        //}
       
        if (collision.gameObject.tag == "Player") {
            OnTouchSound.Play();
            playerOnDumpster = true;

            // Lazy Initialization
            if (playerObject == null) {
                playerObject = collision.gameObject;
                playerPower = playerObject.GetComponent<PlayerPower>();
                playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
            }
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
        if (!dumpsterUsed)
        {
            dumpsterUsed = true;
            StartCoroutine(DoDiveAnimation());
            StopCoroutine(DoDiveAnimation());
        }
        else
        {
            Debug.Log("Dumpster has been used already!");
        }
    }

    private void givePlayerEffect()
    {
        if (ammoOrPowerUp == "powerup")
        {
            Debug.Log("Giving player a powerup");
            givePowerUp();
        }
        else if (ammoOrPowerUp == "ammo")
        {
            Debug.Log("Giving player ammo");
            playerObject.GetComponent<PlayerAmmo>().giveDumpsterAmmo();
        }
    }

    private void givePowerUp()
    {
        playerPower.newPower(PowerupManager.GetManager().RandPower());

    }

    private IEnumerator DoDiveAnimation() // Full diving animation.
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        dumpsterCollider.enabled = false;

        playerObject.GetComponent<SpriteRenderer>().sortingLayerName = "BackGround";

        yield return new WaitForSeconds(diveIdleSeconds);

        playerRigidBody.AddForce(new Vector3(0f, diveUpForce, 0f), ForceMode2D.Impulse);
        givePlayerEffect();

        yield return new WaitForSeconds(diveUpSeconds / 2);
        playerObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        dumpsterCollider.enabled = true;
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
