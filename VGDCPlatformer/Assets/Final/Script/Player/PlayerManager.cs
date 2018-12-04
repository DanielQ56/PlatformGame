using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    private PlayerHealth m_HealthManager;
    private Rigidbody2D m_rb2d;
    public int startHealth = 2;

    public float bounceForce = 20f;
    public float dangerousVelocity = 80f; // When in air and the downward velocity is greater than 80, player dies
                                          // 80 is about the height of the camera.
    public float sideForce = 30f;
    public float hitForce = 10f;

    public float downwardVelocity;  // Testing purpose
    public Transform SpawnPoint;


    //Use this for initialization
    void Start()
    {
        m_HealthManager = GetComponent<PlayerHealth>();
        m_rb2d = GetComponent<Rigidbody2D>();

        if (SpawnPoint)
        {
            transform.position = SpawnPoint.position;
        }
    }


    //will occur when player interacts with Enemy object
    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.name == "bossHurtBox")
        {
            Debug.Log("Hit the boss");
            collide.GetComponentInParent<BossHealth>().hit();
            m_rb2d.velocity = Vector3.zero;
            m_rb2d.AddForce(new Vector3(0, bounceForce, 0), ForceMode2D.Impulse);
        }
        else if (collide.gameObject.tag == "hurtbox")
        {
            Debug.Log("collide with hurtbox");

            //to kill enemy, we tell the enemy script
            Enemy script = collide.gameObject.GetComponentInParent<Enemy>();
            script.Die();

            // Bounce force that push player up a bit
            m_rb2d.velocity = Vector3.zero;
            m_rb2d.AddForce(new Vector3(0, bounceForce, 0), ForceMode2D.Impulse);
        }
        else if (collide.gameObject.tag == "hitbox")
        {
            Debug.Log("collide with hitbox");

            m_HealthManager.damagePlayer();
            if(GetComponent<CharacterController2D>().m_FacingRight)
            {
                m_rb2d.velocity = Vector3.zero;
                m_rb2d.AddForce(new Vector3(-sideForce, hitForce, 0), ForceMode2D.Impulse);
            }
            else
            {
                m_rb2d.velocity = Vector3.zero;
                m_rb2d.AddForce(new Vector3(sideForce, hitForce, 0), ForceMode2D.Impulse);
            }
        }

        if (collide.gameObject.tag == "checkPoint")
        {
            Debug.Log("reach goal");

            SceneManager.LoadScene("TransitionScene");

        }
    }

    // Update is called once per frame
    void Update()
    {

        // check if player's (in air) downward velocity is > dangerousVelocity
        downwardVelocity = m_rb2d.velocity.y;
        if (m_rb2d.velocity.y < -dangerousVelocity)
        {
            Debug.Log("Dangerous Downward Velocity");
            SceneManager.LoadScene("TransitionScene");
        }
    }
}