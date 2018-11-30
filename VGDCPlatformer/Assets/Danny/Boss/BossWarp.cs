using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossWarp : MonoBehaviour {
    public float warpCooldown = 5;
    public string[] probPlayerPlatform;

    string prevLocation = "";
    bool waiting = false;
    GameObject[] checkpoints;
    GameObject player;

	// Use this for initialization
	void Start () {
       checkpoints = GameObject.FindGameObjectsWithTag("checkPoint");
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (!waiting)
        {
            StartCoroutine("delayWarp");
        }
	}

    void warp()
    {
        GetComponent<BossMovement>().warped(chooseCheckpoint(checkpoints));
    }

    GameObject chooseCheckpoint(GameObject[] checks)
    {
        float[] distances = getDistances(checks);
        Array.Sort(distances, checks);
        int num = randNum();
        if(probPlayerPlatform[num] == "closest")
        {
            return checks[0];
        }
        else if(probPlayerPlatform[num] == "second")
        {
            return checks[1];
        }
        else
        {
            return checks[2];
        }
   
    }
    
    int randNum()
    {
        int num = (int)(UnityEngine.Random.value * probPlayerPlatform.Length);
        while (probPlayerPlatform[num] == prevLocation)
        {
            num = (int)(UnityEngine.Random.value * probPlayerPlatform.Length);
        }
        prevLocation = probPlayerPlatform[num];
        return num;
    }

    float[] getDistances(GameObject[] checks)
    {
        float[] distances = new float[checks.Length];
        for (int i = 0; i < checks.Length; ++i)
        {
            distances[i] = Vector2.Distance(player.transform.position, checks[i].transform.position);
        }
        return distances;
    }

    IEnumerator delayWarp()
    {
        waiting = true;
        yield return new WaitForSeconds(warpCooldown);
        waiting = false;
        warp();
    }
}
