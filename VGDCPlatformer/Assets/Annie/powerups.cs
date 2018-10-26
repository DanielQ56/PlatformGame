/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Web.UI;

public class Powerups : MonoBehaviour {

    public class Powerup
    {
        protected int timer; //how long the powerup lasts for
        protected int origValue; //holds the initial value of whatever aspect is being increased
        protected GameObject player; //a reference to the player to adjust the different stats

        public Powerup(ref GameObject player)
        {
            this.player = player;
            timer = 10;
        }

        public virtual Sprite getSprite()
        {
            return null;
        }

        private void tickDown()
        {
            timer--;
        }
    }

    public class Jump: Powerup
    {
        private int extraHeight;
        private Sprite s; //all Sprite s holds the sprite for this specific powerup
        
        public Jump(ref GameObject player): base(ref player)
        {
            extraHeight = 5;
            //origValue = player.GetComponent<PlayerScript>.jump;
        }
        
        //returns the Sprite for this powerup, overloaded for easier calling
        public override Sprite getSprite()
        {
            return s;
        }

        //sets the sprite
        public void setSprite(Sprite s)
        {
            this.s = s;
        }

        //updates the respective stat of the player, in this case it would be jump height
        public void change()
        {
            //player.GetComponent<PlayerScript>.jump += jump;
        }

        //reverts the stat back to the original value when the powerup wears off
        public void revert()
        {
            //player.GetComponent<PlayerScript>.jump = origValue;
        }
    }

    public class Speed: Powerup
    {
        private int speedIncrease;
        private Sprite s; 

        public Speed(ref GameObject player) : base(ref player)
        {
            this.speedIncrease = 10;
            //origValue = player.GetComponent<PlayerScript>.speed.x;
        }

        public override Sprite getSprite()
        {
            return s;
        }

        public void setSprite(Sprite s)
        {
            this.s = s;
        }

        public void change()
        {
            //player.GetComponent<PlayerScript>.speed = new Vector2 <speedIncrease, 0>;
        }

        public void revert()
        {
             //player.GetComponent<PlayerScript>.speed = new Vector<origValue, 0>;
        }
    }

    public class Attack: Powerup
    {
        private int attackIncrease;
        private Sprite s;

        public Attack(ref GameObject player) : base(ref player)
        {
            attackIncrease = 3;
            //origValue = player.GetComponent<PlayerScript>.attack;
        }

        public override Sprite getSprite()
        {
            return s;
        }

        public void setSprite(Sprite s)
        {
            this.s = s;
        }

        public void change()
        {
            //player.GetComponent<PlayerScript>.attack = attackIncrease;
        }

        
        public void revert()
        {
            //player.GetComponent<PlayerScript>.speed = origValue;
        }
    }

    public Powerup[] powerUps;
    int counter;
    int index;
    GameObject powerIcon;
    SpriteRenderer powerRenderer;
    GameObject player;
    float pWidth;
    float pHeight;
*/
    /*Notes: 
     I wasn't sure how to get the individual player stats or how to interact with the player in that matter.
     I just assumed there was a player script but I can adjust/fix that later when we get together on friday. 
     The assumptions for the powerups were: 
        For jump and speed, the powerups will be consumed immediately. Timer to set how long the powerup lasts for 
        For attack, it would be one super attack before wearing off. Or we could have also a timer to say attacks will be powered up for this duration
         */


/*
	// Use this for initialization
    //creates and stores all the powerups for easier access and loads in the sprite for each (I was thinking
    //when the player picks up a powerup the icon for it will appear on the top of the player's head to show
    //what powerup they picked up before disappearing)
	void Start () {
        player = GameObject.Find("player");
        pWidth = player.GetComponent<SpriteRenderer>().bounds.size.x;
        pHeight = player.GetComponent<SpriteRenderer>().bounds.size.y;
        counter = 0;
        index = 0;
        Speed s = new Speed(ref player);
        s.setSprite(Resources.Load<Sprite>("PUps/Speed"));
        Jump j = new Jump(ref player);
        j.setSprite(Resources.Load<Sprite>("PUps/Jump"));
        Attack a = new Attack(ref player);
        a.setSprite(Resources.Load<Sprite>("PUps/Attack"));
        powerUps = new Powerup[] { s, j, a };
        powerIcon = GameObject.Find("powerup");
        powerRenderer = powerIcon.GetComponent<SpriteRenderer>();
	}


    // Update is called once per frame
    //just some tests to see if if i could cycle the icons and alignment
    void Update() {
        alignCenter();
        if (counter % 30 == 0)
        {
            index++;
            if (index > powerUps.Length - 1)
                index = 0;
        }
        powerRenderer.sprite = powerUps[index].getSprite();
        counter++;

    }


    //adjusts the bottom left corner or the powerup icon to be in line with the top left corner of the player icon. (assuming the scaling and everything is correct lol);
    void alignCenter()
    {
        Vector3 pVect = new Vector3(player.GetComponent<SpriteRenderer>().bounds.center.x-pWidth/2, player.GetComponent<SpriteRenderer>().bounds.center.y+pHeight/2);
        Vector3 powerVect = new Vector3(powerRenderer.bounds.center.x - powerRenderer.bounds.size.x / 2, powerRenderer.bounds.center.y - powerRenderer.bounds.size.y / 2);
        Vector3 vect = new Vector3(pVect.x - powerVect.x, pVect.y - powerVect.y);
        Debug.Log(vect.x + " " + vect.y);
        if (!(vect.x == 0 && vect.y == 0))
            powerRenderer.transform.position += vect;
    }
}
*/
