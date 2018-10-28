using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoDisplay : MonoBehaviour {
	private Text ammoText;
	private GameObject playerObject;

	// Use this for initialization
	void Start () {
		ammoText = GetComponent<Text>();
		playerObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		ammoText.text = "Ammo: " + playerObject.GetComponent<playerAmmo>().getCurrentAmmo();
	}

}
