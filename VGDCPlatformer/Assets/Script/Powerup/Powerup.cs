using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class Jump : Powerup
{
    private string name = "Jump";
    private Sprite s;
    private float jumpScaler = 1.5f;

    public Jump(Sprite s)
    {
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
        player.GetComponent<CharacterController2D>().IncreaseJumpBy(jumpScaler);
    }

    public override void revert(GameObject player)
    {
        player.GetComponent<CharacterController2D>().DecreaseJumpBy(jumpScaler);
    }
}


public class Speed : Powerup
{
    private readonly string name = "Speed";
    private Sprite s;
    private float speedScaler = 2f;

    public Speed(Sprite s)
    {
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
        player.GetComponent<PlayerMove>().IncreaseSpeedBy(speedScaler);
    }

    public override void revert(GameObject player)
    {
        player.GetComponent<PlayerMove>().DecreaseSpeedBy(speedScaler);
    }
}

public class Health : Powerup
{
    private readonly string name = "Health";
    private Sprite s;
    private int extraHealth = 1;

    public Health(Sprite s)
    {
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
        player.GetComponent<PlayerHealth>().IncreaseHealthBy(extraHealth);
    }
}

public class Attack : Powerup
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
        //GameObject.FindGameObjectWithTag("SeekingBullet").GetComponent<SeekingBullet>().activate();
    }

    public override void revert(GameObject player)
    {
        //GameObject.FindGameObjectWithTag("SeekingBullet").GetComponent<SeekingBullet>().deactivate();
    }
}