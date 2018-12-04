using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SeekingBullet : MonoBehaviour
{

    bool fired = false;
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
        if(!fired)
        {
            updatePos();
            if(Input.GetMouseButtonDown(0))
            {
                fire();
                fired = true;
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.name == "bossHitBox" || collide.name == "bossHurtBox")
        {
            Debug.Log("Hit the boss");
            collide.GetComponentInParent<BossHealth>().hit();
            OnBecameInvisible();
        }
        else if (collide.name != "BossProjectile" && (collide.tag == "hitbox" || collide.tag == "hurtbox"))
        {
            collide.gameObject.GetComponentInParent<Enemy>().Die();
            OnBecameInvisible();
        }
        
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
            float min = enemies.Values.Min();
            foreach (GameObject en in enemies.Keys)
            {
                if (enemies[en] == min)
                    return en;
            }
        }
        return null;
    }

    private Vector3 changeVelocity(GameObject enemy)
    {
        if (enemy != null && enemy.name != "bossHitBox")
        {
            Debug.Log("Locked On");
            return new Vector3((enemy.GetComponent<SpriteRenderer>().bounds.center.x -
                (playerSprite.GetComponent<SpriteRenderer>().bounds.center.x + playerSprite.bounds.size.x / 2)) * 2,
                (enemy.GetComponent<SpriteRenderer>().bounds.center.y - playerSprite.bounds.center.y)* 2);
        }
        else if(enemy != null && enemy.name == "bossHitBox")
        {
            return new Vector3((enemy.GetComponentInParent<SpriteRenderer>().bounds.center.x -
                (playerSprite.GetComponent<SpriteRenderer>().bounds.center.x + playerSprite.bounds.size.x / 2)) * 3,
                (enemy.GetComponentInParent<SpriteRenderer>().bounds.center.y - playerSprite.bounds.center.y) * 3);
        }
        else
        {
            return new Vector3(30f, 0f);
        }
    }

    void fire()
    {
        SpriteRenderer playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        transform.position = new Vector3(playerSprite.bounds.center.x + playerSprite.bounds.size.x/2, playerSprite.bounds.center.y);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PUps/SeekingBullet");
        GetComponent<Rigidbody2D>().velocity = changeVelocity(getNearestEnemy());
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + (Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x) * 180 / Mathf.PI));
    }

    void updatePos()
    {
        transform.position = player.transform.position;
    }

    public bool hasFired()
    {
        return fired;
    }
}
