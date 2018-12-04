using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPowerup : MonoBehaviour {
    public float cooldownTimer = 10f;


    bool waiting = false;
    Dumpster d;
	// Use this for initialization
	void Start () {
        d = GetComponent<Dumpster>();

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void used()
    {
        StartCoroutine("cooldown");
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        d.respawnPowerup();
    }

}
