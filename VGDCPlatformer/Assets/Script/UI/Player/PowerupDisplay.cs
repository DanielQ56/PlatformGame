using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupDisplay : MonoBehaviour
{
    // Use this for initialization
    private Image panelPowerupImage;
    private PlayerPower powerupComponent;
    void Start()
    {
        powerupComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPower>();
        panelPowerupImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupComponent.isActive())
        {
            panelPowerupImage.color = Color.white;
            panelPowerupImage.sprite = powerupComponent.getCurrentSprite();
        }
        else
        {
            panelPowerupImage.color = new Color(0, 0, 0, 0);
            panelPowerupImage.sprite = null;
        }
    }
}
