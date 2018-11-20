using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class durationBar : MonoBehaviour {
	playerPower powerComponent;
	Image barImage;

	float maxDuration;
	float currentTimer;

	Color transparent;
	Color normal;

	void Start () {
		powerComponent = GameObject.FindWithTag("Player").GetComponent<playerPower>();
		barImage = GetComponent<Image>();
		maxDuration = powerComponent.getTimer();

		transparent = new Color(0,0,0,0);
		normal = new Color(255, 255, 255, 100);
	}
	
	void Update () {
		if (powerComponent.isActive()){
			if (barImage.color != normal){
				barImage.color = normal;
			}
			currentTimer = powerComponent.getTimer();
			barImage.fillAmount = currentTimer / maxDuration;
		} else {
			if (barImage.color != transparent){
				barImage.color = transparent;
			}
		}
	}
}
