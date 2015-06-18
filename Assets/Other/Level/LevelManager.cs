using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour 
{
    public static List<Level> easyLevels = new List<Level>();
    public static List<Level> mediumLevels = new List<Level>();
    public static List<Level> hardLevels = new List<Level>();

	void Start () 
    {
        easyLevels.Add(new Level());

        easyLevels[0].bestMoves = 1;
        easyLevels[0].bestTime = 125F;
        
        for(int i = 0; i < 81; ++i)
        {
            easyLevels[0].arena[i].display = true;
            easyLevels[0].arena[i].value = i;
        }

        easyLevels.Add(new Level());

        easyLevels[1].bestMoves = 2;
        easyLevels[1].bestTime = 225F;

        for (int i = 0; i < 81; ++i)
        {
            easyLevels[1].arena[i].display = true;
            easyLevels[1].arena[i].value = i + 5;
        }
	}
}
