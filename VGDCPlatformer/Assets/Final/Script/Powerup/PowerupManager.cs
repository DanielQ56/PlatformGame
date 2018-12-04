using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class PowerupManager
{
    public static PowerupManager manager;
    Dictionary<string, Powerup> powers = new Dictionary<string, Powerup>();
    Dictionary<string, int[]> powerProbs = new Dictionary<string, int[]>();

    PowerupManager() {
        setPowers();
    }

    private void setPowers()
    {
        powers["Jump"] = new Jump(Resources.Load<Sprite>("PUps/Jump"));
        powers["Speed"] = new Speed(Resources.Load<Sprite>("PUps/Speed"));
        powers["Health"] = new Health(Resources.Load<Sprite>("PUps/Health"));
        powers["Attack"] = new Attack(Resources.Load<Sprite>("PUps/Attack"));
        powerProbs["Speed"] = new int[] { 0, 1, 2, 3 };
        powerProbs["Jump"] = new int[] { 4, 5, 6 };
        powerProbs["Attack"] = new int[] { 7, 8 };
        powerProbs["Health"] = new int[] { 9 };


    }

    public Powerup RandPower()
    {
        string index = new System.Func<string>(() =>
        {
            int num = (int)Random.Range(0f, 9f);
            foreach (string p in powerProbs.Keys)
            {
                if (powerProbs[p].Contains(num))
                {
                    return p;
                }
            }
            return "Speed";
        })();

        Powerup newPower = powers[index];

        return newPower;
    }

    public static PowerupManager GetManager() {
        if (manager == null) {
            manager = new PowerupManager();
        }
        return manager;
    }
}
