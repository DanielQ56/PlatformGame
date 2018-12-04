using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour {
	private Text healthText;
	private playerHealth healthComponent;

	// Use this for initialization
	void Start () {
		healthText = GetComponent<Text>();
		healthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = healthComponent.getCurrentHealth().ToString();
	}
}
