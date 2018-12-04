using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPoint : MonoBehaviour {
	public string nextScene;
	GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Something touched the flag");
		Debug.Log(other.gameObject.tag);

		if(other.gameObject == player){
			Debug.Log("Reached goal");
			SceneManager.LoadScene(nextScene);
		}
	}
}
