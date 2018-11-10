using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

    public class Powerup
    {
        private string name;
        public Powerup() { name = "Powerup"; }

        public virtual Sprite getSprite()
        {
            return null;
        }
        public virtual string getName() { return name; }
        public virtual void change(GameObject player) { }
        public virtual void revert(GameObject player) { }
        public virtual void fire() { }
    }

    public class Jump: Powerup
    {
        private string name;
        private Sprite s;
        private float extraHeight; 

        public Jump(Sprite s)
        {
            name = "Jump";
            this.s = s;
            extraHeight = 100f;
        }

        public override string getName()
        {
            return name;
        }

        public override Sprite getSprite()
        {
            return s;
        }

        public override void change(GameObject player)
        {
            player.GetComponent<PlayerMovementBeginner>().m_JumpForce += extraHeight;
        }

        public override void revert(GameObject player)
        {
            player.GetComponent<PlayerMovementBeginner>().m_JumpForce -= extraHeight;
        }
    }

    public class Speed : Powerup
    {
        private string name;
        private Sprite s;
        private float extraSpeed;

        public Speed(Sprite s)
        {
            name = "Speed";
            this.s = s;
            extraSpeed = 100f;
        }

        public override string getName()
        {
            return name;
        }

        public override Sprite getSprite()
        {
            return s;
        }

        public override void change(GameObject player)
        {
            player.GetComponent<PlayerMovementBeginner>().runSpeed += extraSpeed;
        }

        public override void revert(GameObject player)
        {
            player.GetComponent<PlayerMovementBeginner>().runSpeed -= extraSpeed;
        }
    }

    public class Health : Powerup
    {
        private string name;
        private Sprite s;
        private int extraHealth;

        public Health(Sprite s)
        {
            name = "Health";
            this.s = s;
            extraHealth = 1;
        }

        public override string getName()
        {
            return name;
        }

        public override Sprite getSprite()
        {
            return s;
        }
        public override void change(GameObject player)
        {
            player.GetComponent<playerHealth>().setCurrentHealth(player.GetComponent<playerHealth>().getCurrentHealth() + extraHealth);
        }
    }

    public class Attack: Powerup
    {
        private string name;
        private Sprite s;

        public Attack(Sprite s)
        {
            name = "Seeking Bullet";
            this.s = s;
        }

        public override string getName()
        {
            return name;
        }

        public override Sprite getSprite()
        {
            return s;
        }

        public override void change(GameObject player)
        {
            GameObject.FindGameObjectWithTag("SeekingBullet").GetComponent<SeekingBullet>().activate(); 
        }

        public override void revert(GameObject player)
        {
            GameObject.FindGameObjectWithTag("SeekingBullet").GetComponent<SeekingBullet>().deactivate();
        }
    }

    Dictionary<string, Powerup> powers = new Dictionary<string, Powerup>();
    Dictionary<string, int[]> powerProbs = new Dictionary<string, int[]>();
    Powerup currentPower;

    // Use this for initialization
    void Start() {
        setPowers();
	}
	
	// Update is called once per frame
	void Update() { }

    private void setPowers()
    {
        powers["Jump"] = new Jump(Resources.Load<Sprite>("PUps/Jump"));
        powers["Speed"] = new Speed(Resources.Load<Sprite>("PUps/Speed"));
        powers["Health"] = new Health(Resources.Load<Sprite>("PUps/Health"));
        powers["Attack"] = new Attack(Resources.Load<Sprite>("PUps/Attack"));
        powerProbs["Speed"] = new int[]{ 0, 1, 2, 3};
        powerProbs["Jump"] = new int[] { 4, 5, 6 };
        powerProbs["Attack"] = new int[] { 7, 8 };
        powerProbs["Health"] = new int[] { 9 };


    }

    private void randPower()
    {
        currentPower = powers[new System.Func<string>(() =>
        {
            int num = (int)Random.Range(0f, 9f);
            foreach (string p in powerProbs.Keys)
            {
                if(powerProbs[p].Contains(num))
                {
                    return p;
                }
            }
            return "Speed";
        })()];
    }


    public void givePowerUp()
    {
        randPower();
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerPower>().newPower(currentPower);
    }
}
