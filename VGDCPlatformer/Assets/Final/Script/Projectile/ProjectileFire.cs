using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileFire : MonoBehaviour {

	public GameObject projectilePrefab;
	public GameObject player;
	private PlayerAmmo ammoControl;
	public float launchSpeed = 5f;
	private bool parentFacingRight;
	public int ammoCount;
	public float timeBetweenProj = 0.3333f;
	private float timestamp;

    private bool isTrackingBullet = false;
    private bool trackingFired = false;

	public Sprite[] projectileSprites;
	
	// Use this for initialization
	void Start () {
		ammoControl = player.GetComponent<PlayerAmmo>();
		ammoCount = ammoControl.getCurrentAmmo();
	}
	
	// Update is called once per frame
	void Update () {
		ammoCount = ammoControl.getCurrentAmmo();
		//if (Input.GetButtonDown("Fire1")) {
		//	FireProj();
		//}
		if (Input.GetMouseButtonDown(0) && ammoCount > 0 && Time.time >= timestamp) {
            Debug.Log("shoot something " +  isTrackingBullet);
			Vector2 shootDirection;
			shootDirection=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;


            if (isTrackingBullet)
            {
                // bullet that aim automatically 
                Transform trans = getNearestEnemy();
                if (trans == null)
                {
                    FireDirectedProj(shootDirection);
                }
                else
                {
                    FireDirectedProj(trans.position);
                }

            }
            else
            {
                // regular bullet
                FireDirectedProj(shootDirection);
            }


            ammoControl.decreaseAmmo(1);
			timestamp = Time.time + timeBetweenProj;
		}
		
	}
	
	public void FireProj() { //for firing only left or right

		parentFacingRight = player.GetComponent<CharacterController2D>().m_FacingRight;
		GameObject Clone;
		Clone = (Instantiate(projectilePrefab, transform.position, transform.rotation));
		Clone.GetComponent<projectileScript>().facingRight = parentFacingRight;	
	}
	
	public void FireDirectedProj(Vector2 direct) {
		int i = Random.Range(0, projectileSprites.Length);
		GameObject Clone;
		Clone = Instantiate(projectilePrefab, transform.position, transform.rotation);
		Clone.GetComponent<SpriteRenderer>().sprite = projectileSprites[i];
        Clone.GetComponent<Rigidbody2D>().velocity = new Vector2(direct.x, direct.y).normalized * launchSpeed;
    }

    public void ActivateTracking()
    {
        isTrackingBullet = true;
        trackingFired = false;
    }

    public void DeactivateTracking()
    {
        isTrackingBullet = false;
    }

    internal bool HasFiredTrackingBullet()
    {
        return trackingFired;
    }

    private Transform getNearestEnemy()
    {
        Dictionary<float, Transform> enemies = new Dictionary<float, Transform>();

        foreach (GameObject en in GameObject.FindGameObjectsWithTag("hitbox"))
        {
            float dis = Vector3.Distance(transform.position, en.transform.position);
            enemies[dis] = en.transform;
        }
        if (enemies.Count != 0)
        {
            float max = enemies.Keys.Max();
            return enemies[max];
        }
        return null;
    }
}
