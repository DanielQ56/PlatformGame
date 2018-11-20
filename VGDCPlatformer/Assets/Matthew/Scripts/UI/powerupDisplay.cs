using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerupDisplay : MonoBehaviour {

	// Use this for initialization
	private Image panelPowerupImage;
	private playerPower powerupComponent;
	void Start () {
		powerupComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<playerPower>();
		panelPowerupImage = GetComponent<Image>();
		panelPowerupImage.sprite = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (panelPowerupImage.sprite == null) {
			if (powerupComponent.currentPowerPresent()){
				panelPowerupImage.color = new Color(255, 255, 255, 255);
				panelPowerupImage.sprite = powerupComponent.getCurrentPowerSprite();
			}
		} else {
			if (!powerupComponent.currentPowerPresent() && !powerupComponent.powerBeingUsedPresent()) {
				panelPowerupImage.color = new Color(0,0,0,0);
				panelPowerupImage.sprite = null;
			}
		}
	}
}
