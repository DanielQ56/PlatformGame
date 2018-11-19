using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHazard : MonoBehaviour {


    private Rigidbody2D body;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(transform.position, -transform.up, Color.blue, 20f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 90000000f, LayerMask.NameToLayer("Level"));
        
        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("fall");  
            body.bodyType = RigidbodyType2D.Dynamic;
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
        }
    }
}
