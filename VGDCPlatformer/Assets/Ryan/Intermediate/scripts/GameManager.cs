using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager{

    public static Transform spawnPoint;

	public static void UpdateSpawn(Transform checkPoint)
    {
        spawnPoint = checkPoint;
    }
}
    
