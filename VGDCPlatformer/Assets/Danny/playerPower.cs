using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPower : MonoBehaviour {


    public Powerups.Powerup currentPower = null;
    public Powerups.Powerup powerBeingUsed = null;
    GameObject power;
    SpriteRenderer powerSprite;
    SpriteRenderer playerSprite;
    bool activated = false;
    bool started = false;
    float timer = 10f;
    float obtainedTime = 2f;


	// Use this for initialization
	void Start () {
        power = GameObject.FindGameObjectWithTag("powerup");
        powerSprite = power.GetComponent<SpriteRenderer>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        alignCenter();
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (currentPower != null)
            {
                if (powerBeingUsed == null)
                { 
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
        if(currentPower != null && currentPower.getName() == "Health")
        {
            timer = 1f;
            powerBeingUsed = currentPower;
            currentPower = null;
            activated = true;
        }
        if (activated)
        {
            if (!started)
            {
                activatePower();
            }
            else if(timer <= 0)
            {
                reset();
            }
            else if(powerBeingUsed.getName() == "Seeking Bullet")
            {
                if (GameObject.FindGameObjectWithTag("SeekingBullet").GetComponent<SeekingBullet>().hasFired())
                    reset();
            }
            decrementTimer();
        }
    }

    void activatePower()
    {
        setSprite();
        powerBeingUsed.change(GameObject.FindGameObjectWithTag("Player"));
        started = true;
    }

    void reset()
    {
        powerBeingUsed.revert(GameObject.FindGameObjectWithTag("Player"));
        revertSprite();
        timer = 10f;
        obtainedTime = 2f;
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
        Vector3 pVect = new Vector3(playerSprite.bounds.center.x, playerSprite.bounds.center.y + (playerSprite.bounds.size.y / (7 / 4)));
        powerSprite.transform.position = pVect;
    }

    public void newPower(Powerups.Powerup p)
    {
        if(currentPower == null)
            currentPower = p;
    }

    public Sprite getCurrentSprite()
    {
        return powerBeingUsed.getSprite();
    }

    private void setSprite()
    {
        powerSprite.sprite = powerBeingUsed.getSprite();
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
