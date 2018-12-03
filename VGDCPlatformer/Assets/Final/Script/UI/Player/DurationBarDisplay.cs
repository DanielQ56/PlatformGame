using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationBarDisplay : MonoBehaviour {

    private Image barImage;
    private PlayerPower powerupComponent;

    float maxDuration;
    float currentTimer;

    Color transparent;
    Color normal;

    void Start()
    {
        powerupComponent = GameObject.FindWithTag("Player").GetComponent<PlayerPower>();
        barImage = GetComponent<Image>();
        maxDuration = powerupComponent.getTimer();

        transparent = new Color(0, 0, 0, 0);
        normal = new Color(255, 255, 255, 100);
    }

    void Update()
    {
        if (powerupComponent.isActive())
        {
            if (barImage.color != normal)
            {
                barImage.color = normal;
            }
            currentTimer = powerupComponent.getTimer();
            barImage.fillAmount = currentTimer / maxDuration;
        }
        else
        {
            if (barImage.color != transparent)
            {
                barImage.color = transparent;
            }
        }
    }
}
