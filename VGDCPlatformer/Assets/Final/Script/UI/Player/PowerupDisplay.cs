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
        if (panelPowerupImage.sprite == null)
        {
            if (powerupComponent.currentPowerPresent())
            {
                panelPowerupImage.color = new Color(255, 255, 255, 255);
                panelPowerupImage.sprite = powerupComponent.getCurrentPowerSprite();
            }
        }
        else
        {
            if (!powerupComponent.currentPowerPresent() && !powerupComponent.powerBeingUsedPresent())
            {
                panelPowerupImage.color = new Color(0, 0, 0, 0);
                panelPowerupImage.sprite = null;
            }
        }
    }
}
