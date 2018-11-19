using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    private string m_SceneName;
    private playerHealth m_HealthManager;
    private Rigidbody2D m_rb2d;

    public int startHealth = 2;

    public float bounceForce = 20f;
    public float dangerousVelocity = 60f; // When in air and the downward velocity is greater than 40, player dies
                                          // 40 is about the height of the camera.

    [SerializeField] Transform SpawnPoint;


    //Use this for initialization
    void Start()
    {
        m_SceneName = SceneManager.GetActiveScene().name;
        m_HealthManager = GetComponent<playerHealth>();

        m_rb2d = GetComponent<Rigidbody2D>();

        GameManager.UpdateSpawn(SpawnPoint);
        gameObject.transform.position = SpawnPoint.position;
    }


    //will occur when player interacts with Enemy object
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "hurtbox")
        {
            Debug.Log("collide with hurtbox");

            //to kill enemy, we tell the enemy script
            TheEnemy script = collide.gameObject.GetComponentInParent<TheEnemy>();
            script.Die();

            // Bounce force that push player up a bit
            m_rb2d.velocity = Vector3.zero;
            m_rb2d.AddForce(new Vector3(0, bounceForce, 0), ForceMode2D.Impulse);
        }
        else if (collide.gameObject.tag == "hitbox")
        {
            Debug.Log("collide with hitbox");

            m_HealthManager.damagePlayer();
        }

        if (collide.gameObject.tag == "checkPoint")
        {
            Debug.Log("change respawn point");

            SpawnPoint = collide.transform;

            GameManager.UpdateSpawn(collide.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // check if player's (in air) downward velocity is > dangerousVelocity
        if (m_rb2d.velocity.y < -dangerousVelocity)
        {
            m_HealthManager.damagePlayer();
            transform.position = GameManager.spawnPoint.position;
        }
    }
}
