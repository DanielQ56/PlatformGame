using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Private Member")]
    Rigidbody2D m_RigidBody2D;
    private bool m_Grounded = false;
    private float horizontalMove = 0f;

    [Header("configurable")]
    public float m_RunSpeed = 20f;
    public float m_JumpForce = 400f;

    [Header("Layer Value")]
    public int groundLayer = 8; // default layer: Ground
    public int monsterLayer = 10; // default layer: Ground

    void Start () {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * m_RunSpeed;

        Vector3 facing = transform.localScale;
        facing.x = (int)Input.GetAxisRaw("Horizontal") == 0 ? transform.localScale.x : (int)Input.GetAxisRaw("Horizontal");
        transform.localScale = facing;

        if (m_Grounded && Input.GetButtonDown("Jump"))
        {
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
            m_Grounded = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f * Time.fixedDeltaTime, m_RigidBody2D.velocity.y);
        m_RigidBody2D.velocity = targetVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_Grounded |= groundLayer == collision.gameObject.layer;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        m_Grounded &= !(groundLayer == collision.gameObject.layer) | m_Grounded;
    }
}
