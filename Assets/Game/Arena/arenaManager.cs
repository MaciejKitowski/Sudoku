using UnityEngine;
using System.Collections;

public class arenaManager : MonoBehaviour 
{
    public squareController[,] square;
	
	void Start () 
    {
        square = new squareController[3, 3];

        for (int x = 0, i = 0; x < 3; ++x)
        {
            for (int y = 0; y < 3; ++y, ++i) square[x,y] = gameObject.transform.GetChild(i).gameObject.GetComponent<squareController>();
        }
	}
}
