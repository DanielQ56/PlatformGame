using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDuplicate : MonoBehaviour {
    public BossHealth bossHealth;
    public float duplicateTime;
    private int currHealth;
    private float startTime;
    private float currTime;
    private int numDuplicates = 0;

	// Use this for initialization
	void Start () {
        bossHealth = gameObject.GetComponent<BossHealth>();
        startTime = Time.time;
        currTime = 0f;
        currHealth = bossHealth.currHealth;
	}
	
	// Update is called once per frame
	void Update () {
        currTime = Time.time - startTime;
        Debug.Log("Time: " + currTime);
        currHealth = bossHealth.currHealth;
        if (currTime >= duplicateTime) {
            Duplicate();
            startTime = Time.time;
            currTime = 0f;
        }
    }

    public void ResetTime() {
        startTime = Time.time;
        currTime = 0f;
    }

    void Duplicate() {
        Instantiate(gameObject);
        numDuplicates++;
        Debug.Log("Boss Duplicated");
        int healthNew = currHealth / (2 * numDuplicates);
        if (healthNew < 1)
        {
            healthNew = 1;
        }
        GameObject[] bossList = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject boss in bossList){
            boss.GetComponent<BossHealth>().maxHealth = healthNew;
            boss.GetComponent<BossHealth>().currHealth = healthNew;
        }
        currHealth = healthNew;
    }
}
