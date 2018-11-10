using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SeekingBullet : MonoBehaviour
{

    bool activated = false;
    bool fired = false;
    bool finished = false;
    public GameObject SeekingBulletPrefab;
    SpriteRenderer playerSprite;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && !fired)
        {
            if(Input.GetMouseButtonDown(0))
            {
                fire();
                fired = true;
            }
        }
    }

    private void OnBecameInvisible()
    {
        done();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "hurtbox")
        {
            TheEnemy script = collision.GetComponentInParent<TheEnemy>();
            script.Die();
            done();
        }
    }

    private void done()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        finished = true;
        activated = false;
        fired = false;
    }

    public bool hasFired()
    {
        return fired;
    }

    public bool isFinished()
    {
        return finished;
    }

    public void reset()
    {
        finished = false;
    }

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    private GameObject getNearestEnemy()
    {
        Dictionary<GameObject, float> enemies = new Dictionary<GameObject, float>();
        foreach (GameObject en in GameObject.FindGameObjectsWithTag("hitbox"))
        {
            Vector3 pos = en.transform.position;
            enemies[en] = Mathf.Sqrt(Mathf.Pow(pos.x - (playerSprite.bounds.center.x + playerSprite.bounds.size.x / 2), 2) + Mathf.Pow(pos.y - (playerSprite.bounds.center.y), 2));
        }
        if (enemies.Count != 0)
        {
            float max = enemies.Values.Max();
            foreach (GameObject en in enemies.Keys)
            {
                if (enemies[en] == max)
                    return en;
            }
        }
        return null;
    }

    private Vector3 changeVelocity(GameObject enemy)
    {
        if (enemy != null)
        {
            return new Vector3((enemy.GetComponent<SpriteRenderer>().bounds.center.x -
                (playerSprite.GetComponent<SpriteRenderer>().bounds.center.x + playerSprite.bounds.size.x / 2)) / 2,
                (enemy.GetComponent<SpriteRenderer>().bounds.center.y - playerSprite.bounds.center.y)/ 2);
        }
        else
        {
            return new Vector3(30f, 0f);
        }
    }

    public void fire()
    {
        SpriteRenderer playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        transform.position = new Vector3(playerSprite.bounds.center.x + playerSprite.bounds.size.x/2, playerSprite.bounds.center.y);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PUps/SeekingBullet");
        GetComponent<Rigidbody2D>().velocity = changeVelocity(getNearestEnemy());
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + (Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x) * 180 / Mathf.PI));
    }
}
