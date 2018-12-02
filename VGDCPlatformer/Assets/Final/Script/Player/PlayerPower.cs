using System;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{

    public Powerup currentPower = null;
    public Powerup powerBeingUsed = null;
    //GameObject power;
    SpriteRenderer powerSprite;
    SpriteRenderer playerSprite;
    public bool activated = false;
    public bool started = false;
    private float timer = 10f;
    public float defaultTimer;

    // Use this for initialization
    void Start()
    {
        powerSprite = GameObject.FindGameObjectWithTag("powerup").GetComponent<SpriteRenderer>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentPower != null)
            {
                if (powerBeingUsed == null)
                {
                    timer = defaultTimer;
                    powerBeingUsed = currentPower;
                    currentPower = null;
                    activated = true;
                }
                else
                    Debug.Log("You currently have a power");
            }
            else
            {
                Debug.Log("You Don't have a power to use!");
            }
        }
        usePower();

    }

    void usePower()
    {
        if (currentPower != null && currentPower.getName() == "Health")
        {
            timer = 1f;
            powerBeingUsed = currentPower;
            currentPower = null;
            activated = true;
        }
        if (activated)
        {
            alignCenter();
            if (!started)
            {
                activatePower();
            }
            else if (timer <= 0)
            {
                reset();
            }
            else if (powerBeingUsed.getName() == "Seeking Bullet")
            {
                //if (GameObject.FindGameObjectWithTag("SeekingBullet").GetComponent<SeekingBullet>().hasFired())
                    reset();
            }
            decrementTimer();
        }
    }

    void activatePower()
    {
        setSprite();
        powerBeingUsed.change(gameObject);
        started = true;
    }

    void reset()
    {
        powerBeingUsed.revert(gameObject);
        revertSprite();
        timer = defaultTimer;
        activated = false;
        powerBeingUsed = null;
        started = false;
    }

    void decrementTimer()
    {
        timer -= Time.deltaTime;
    }

    void alignCenter()
    {
        Vector3 scale = powerSprite.transform.localScale;
        if (playerSprite.transform.localScale.x > 0)
        {
            scale.x = 0.3f;
        }
        else
        {
            scale.x = -0.3f;
        }
        powerSprite.transform.localScale = scale;
    }

    public void newPower(Powerup p)
    {
        if (currentPower == null)
            currentPower = p;

    }

    public Sprite getCurrentSprite()
    {
        return powerBeingUsed.getSprite();
    }

    private void setSprite()
    {
        powerSprite.sprite = powerBeingUsed.getSprite();
        Invoke("revertSprite", timer / 3);
    }

    private void revertSprite()
    {
        powerSprite.sprite = null;
    }

    public bool hasActivated()
    {
        return activated;
    }

    public bool isActive()
    {
        return activated && started;
    }

    // For duration bar
    public float getTimer()
    {
        return timer;
    }

    // Needed to show current powerup while it hasn't been activated yet
    public Sprite getCurrentPowerSprite()
    {
        return currentPower.getSprite();
    }

    // Returns if currentPower is NOT null; needed to display powerup while player hasn't it activated yet
    public bool currentPowerPresent()
    {
        return currentPower != null;
    }

    // Same reason as currentPowerPresent
    public bool powerBeingUsedPresent()
    {
        return powerBeingUsed != null;
    }

}
