using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour {
	public string sceneToLoad;

	//FROM DUMPSTER

    //[Header("Dive Animation")]
    //public float diveIdleSeconds;
    //public float diveUpForce = 0f;
    //public float diveUpSeconds = 0;

    // MAKE SURE PLAYER OBJECT HAS "Player" TAG!
    //private GameObject playerObject;
    //private Rigidbody2D playerRigidBody;
    private bool playerOnDumpster;

    //private BoxCollider2D dumpsterCollider;
	
	// Use this for initialization
	void Start () {
		//dumpsterCollider = GetComponent<BoxCollider2D>(); // For DoDiveAnimation()
	}
	
    private void FixedUpdate()
    {
        if (playerOnDumpster && Input.GetButtonDown("Vertical")) // Button is currently "s"
        {
			SceneManager.LoadScene(sceneToLoad);
        }
    }
	
	void OnTriggerEnter2D(Collider2D collid) {
		if (collid.gameObject.tag == "Player") {
			playerOnDumpster = true;
		}
	}
}
