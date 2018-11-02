using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour {

    private readonly int[] directions = { -1, 1 };
    private int direction;

    [Header("Configurable")]
    public GameObject m_Parent;
    public Transform m_Waypoint1;
    public Transform m_Waypoint2;

    public float m_PushForce = 5f;
    public float m_MoveSpeed = 1.5f;

	void Start () {

        /* Randomly chooce a direction for monster,
         * -1 facing left, 1 facing right.
         */
        int index = Random.Range(0, 2);
        direction = directions[index];
        transform.localScale = 
            new Vector3(transform.localScale.x * -direction, 3, 3);
    }

    void Update() {
        /* Detect if monster reaches the edge, should turn back. 
         * Right now only support horizontal movement
         */
        if (transform.position.x < m_Waypoint1.position.x 
            || transform.position.x > m_Waypoint2.position.x) {
            direction = -direction;

            Vector3 facing = transform.localScale;
            facing.x = -facing.x;
            transform.localScale = facing;
        }

        transform.Translate(new Vector2(direction * m_MoveSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* When players hit the top side of the monster, 
         * give player a upward force and then self-destruct 
         */
        if (collision.gameObject.tag == "Player") {
            Destroy(m_Parent);

            Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

            rb2d.velocity = Vector3.zero;
            rb2d.AddForce(new Vector2(0, m_PushForce), ForceMode2D.Impulse);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* When players hit the left, right or bottom side of the monster, 
         * player kills itself
         */
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);

            Debug.Log("player died");
            Time.timeScale = 0; // This will pause the game
        }
    }
}
