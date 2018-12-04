using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //set the player as a child to the platform gaemObject
        //this allows movement of the player with moving platforms
        if (collision.gameObject.CompareTag("Player"))
        { 

            collision.collider.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        //removes the player from being a child of this platform gameObject
        //once player is not on the platform.
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
