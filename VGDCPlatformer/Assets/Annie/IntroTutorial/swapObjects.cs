using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class swapObjects: MonoBehaviour {

	public GameObject oldObject;
	public GameObject newObject;
	public bool useDumpCond = false;
	private bool showText;
	private bool playerOnDumpster = false;
	
	// Use this for initialization
	void Start () {
		if(newObject != null) {
			newObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(useDumpCond && playerOnDumpster && Input.GetButtonDown("Vertical")) {
			oldObject.SetActive(false);
			newObject.SetActive(true);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collid) {
		if (collid.gameObject.tag == "Player") {
			playerOnDumpster = true;
		}
	}
}
