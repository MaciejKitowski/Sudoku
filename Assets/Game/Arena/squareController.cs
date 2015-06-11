using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class squareController : MonoBehaviour 
{
    public areaController[,] area;
	
	void Start () 
    {
	    area = new areaController[3,3];

        for (int y = 0, i = 0; y < 3; ++y)
        {
            for (int x = 0; x < 3; ++x, ++i) area[x, y] = gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.GetComponent<areaController>();
        }
	}

    public areaController getArea(int ID)
    {
        return gameObject.transform.GetChild(0).gameObject.transform.GetChild(ID).gameObject.GetComponent<areaController>();
    }

    public bool checkSquare()
    {
        for (int y = 0; y < 3; ++y)
        {
            for (int x = 0; x < 3; ++x)
            {
                for (int b = 0; b < 3; ++b)
                {
                    for (int a = 0; a < 3; ++a) if (area[x, y].value == area[a, b].value && area[x,y] != area[a,b]) return false;
                }
            }
        }
        return true;
    }
}
