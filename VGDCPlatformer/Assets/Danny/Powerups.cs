using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

    public class Powerup
    {
        public Powerup() { }

        public virtual Sprite getSprite()
        {
            return null;
        }

        public virtual void change() { }
        public virtual void revert() { }
    }

    public class Jump: Powerup
    {
        private Sprite s;
        private float extraHeight; 

        public Jump(Sprite s)
        {
            this.s = s;
            extraHeight = 100f;
        }

        public override Sprite getSprite()
        {
            return s;
        }

        public override void change()
        {
            PlayerMovementBeginner.m_JumpForce += extraHeight;
        }

        public override void revert()
        {
            PlayerMovementBeginner.m_JumpForce -= extraHeight;
        }
    }

    public class Speed : Powerup
    {
        private Sprite s;
        private float extraSpeed;

        public Speed(Sprite s)
        {
            this.s = s;
            extraSpeed = 100f;
        }

        public override Sprite getSprite()
        {
            return s;
        }

        public override void change()
        {
            PlayerMovementBeginner.runSpeed += extraSpeed;
        }

        public override void revert()
        {
            PlayerMovementBeginner.runSpeed-= extraSpeed;
        }
    }


    string[] p = { "Jump", "Speed" };
    Dictionary<string, Powerup> powers = new Dictionary<string, Powerup>();
    public static bool activated = false;
    bool finished = false;
    bool started = false;
    float timer = 10;
    Powerup currentPower;

    // Use this for initialization
    void Start() {
        setPowers();
        randPower();
	}
	
	// Update is called once per frame
	void Update() {
		if(activated && !finished)
        
        {
            if (!started)
            {
                Debug.Log("Started");
                setSprite();
                currentPower.change();
                timer -= Time.deltaTime;
                started = true;
            }
            else if(timer <=0)
            {
                Debug.Log("Finished");
                finished = true;
                currentPower.revert();
                revertSprite();
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }


	}

    public Sprite getCurrentPowerupSprite() {
        return currentPower.getSprite();
    }

    private void setSprite()
    {
        GameObject.FindGameObjectWithTag("powerup").GetComponent<SpriteRenderer>().sprite = currentPower.getSprite();
    }

    private void revertSprite()
    {
        GameObject.FindGameObjectWithTag("powerup").GetComponent<SpriteRenderer>().sprite = null;
    }

    private void setPowers()
    {
        powers["Jump"] = new Jump(Resources.Load<Sprite>("PUps/Jump"));
        powers["Speed"] = new Speed(Resources.Load<Sprite>("PUps/Speed"));
    }

    private void randPower()
    {
        currentPower = powers[p[new System.Func<int>(() =>
        {
            int num = (int)(Random.value * p.Length);
            if (num == p.Length)
                return num - 1;
            return num;
        })()]];
    }

    public static void activate()
    {
        Debug.Log("Activated");
        activated = true;
    }

    public static bool hasActivated()
    {
        return activated;
    }

    // Needed to display powerup sprite in UI
    public bool isActive() {
        return activated && !finished;
    }
}
