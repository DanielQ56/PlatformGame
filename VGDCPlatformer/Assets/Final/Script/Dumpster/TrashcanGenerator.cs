using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanGenerator : MonoBehaviour {
    GameObject[] trashcans;
    List<int> idx;

    public int maxTrashcanCount = 4;
    public float durationBetweenSpawn = 40;
	// Use this for initialization
	void Start () {
        trashcans = GameObject.FindGameObjectsWithTag("trashcan");

        Debug.Log("trashcan counts: " + trashcans.Length);

        foreach (GameObject go in trashcans) {
            go.SetActive(false);
        }
        idx = new List<int>();
        int c = 0;
        while (c < maxTrashcanCount)
        {
            int i = Random.Range(0, trashcans.Length);
            if (!idx.Contains(i))
            {
                idx.Add(i);
                c++;
            }
        }

        float initialTime = durationBetweenSpawn;
        for (int i = 0; i < maxTrashcanCount; i++)
        {
            StartCoroutine(activateTrashcan(idx[i], initialTime));
            StopCoroutine(activateTrashcan(idx[i], initialTime));
            initialTime += durationBetweenSpawn;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator activateTrashcan(int id, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        //trashcans[id].SetActive(true);
        trashcans[id].SetActive(true);
    }

}
