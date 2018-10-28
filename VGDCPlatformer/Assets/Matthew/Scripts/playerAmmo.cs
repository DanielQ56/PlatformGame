using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAmmo : MonoBehaviour {

	public int maxAmmo = 5;
	public int startingAmmo = 1;

	public int ammoFromDumpster = 3;

	private int currentAmmo;

	// Use this for initialization
	void Start () {
		currentAmmo = startingAmmo;
	}
	
	public bool hasMaxAmmo()
	{
		return currentAmmo >= maxAmmo;
	}

	public int getCurrentAmmo() {
		return currentAmmo;
	}

	private void increaseAmmo(int amount)
	{
		Debug.Log("Old: " + currentAmmo);
		for (int i =0; i < amount; i++) {
			currentAmmo++;
			if (currentAmmo >= maxAmmo) {
				break;
			}
		}
		Debug.Log("New: " + currentAmmo);
	}

	public void giveDumpsterAmmo() {
		Debug.Log("giveDumpsterAmmo is running");
		if (!hasMaxAmmo()) 
		{
			Debug.Log("Increasing ammo");
			increaseAmmo(ammoFromDumpster);
		}
	}


}
