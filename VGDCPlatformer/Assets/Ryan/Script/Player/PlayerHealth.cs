using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	public int invincibilitySeconds;

	private int currentHealth;
	private bool invincibleFrameOn;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}

	void FixedUpdate() {
		if (currentHealth == 0) {
			onDeath();
		}
	}

	public int getCurrentHealth() {
		return currentHealth;
	}

	public void setCurrentHealth(int newHealth) {
		currentHealth = newHealth;
	}

	public void damagePlayer() {
		if (!invincibleFrameOn) {
			decrementHealth();
			StartCoroutine(DoIFrames());
			StopCoroutine(DoIFrames());
		}
	}

	private IEnumerator DoIFrames()
	{
		invincibleFrameOn = true;
		yield return new WaitForSeconds(invincibilitySeconds);
		invincibleFrameOn = false;
	}

	public void decrementHealth() {
		if (currentHealth > 0) {
		currentHealth--;
		}
	}

	private void onDeath() {
		Debug.Log("You died!");
        SceneManager.LoadScene("TransitionScene");

    }

    internal void IncreaseHealthBy(int extraHealth)
    {
        int newHealth = currentHealth + extraHealth;
        currentHealth = newHealth >= maxHealth ? maxHealth : newHealth;
    }
}
