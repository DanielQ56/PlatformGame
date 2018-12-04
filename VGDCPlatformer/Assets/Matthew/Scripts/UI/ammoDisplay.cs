using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoDisplay : MonoBehaviour {
	private Text ammoText;
	private playerAmmo ammoComponent;

	// Use this for initialization
	void Start () {
		ammoText = GetComponent<Text>();
		ammoComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<playerAmmo>();
	}
	
	// Update is called once per frame
	void Update () {
		ammoText.text = ammoComponent.getCurrentAmmo().ToString() + " / " + ammoComponent.maxAmmo.ToString();
	}

}
