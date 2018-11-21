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
    public float timer = 2f;

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
        alignCenter();
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



}
