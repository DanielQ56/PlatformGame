using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerupDisplay : MonoBehaviour {

	// Use this for initialization
	private Image panelPowerupImage;
	private Powerups powerupComponent;
	void Start () {
		powerupComponent = GameObject.FindGameObjectWithTag("powerup").GetComponent<Powerups>();
		panelPowerupImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (powerupComponent.isActive()) {
		panelPowerupImage.color = new Color(255,255,255,255);
		panelPowerupImage.sprite = powerupComponent.getCurrentPowerupSprite();
		} else {
			panelPowerupImage.color = new Color(0,0,0,0);
			panelPowerupImage.sprite = null;
		}
	}
}
