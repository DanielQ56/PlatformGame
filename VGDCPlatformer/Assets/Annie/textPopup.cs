using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPopup : MonoBehaviour {

	public string showThisText;
	private bool showText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collid) {
		if (collid.tag == "Player") {
			showText = true;
		}
		
	}
	
	void OnGUI() {
		if (showText == true) {
			
			
		}
		
	}
}
