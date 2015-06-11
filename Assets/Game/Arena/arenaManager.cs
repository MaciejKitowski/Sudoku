using UnityEngine;
using System.Collections;

public class arenaManager : MonoBehaviour 
{
    public squareController[,] square;
    public areaController[,] area;
	
	void Start () 
    {
        square = new squareController[3, 3];
        area = new areaController[9, 9];

        for (int y = 0, i = 0; y < 3; ++y)
        {
            for (int x = 0; x < 3; ++x, ++i) square[x,y] = gameObject.transform.GetChild(i).gameObject.GetComponent<squareController>();
        }

        loadArea(); 
	}


    public bool checkHorizontal()
    {
        for (int y = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9; ++x)
            {
                for (int a = 0; a < 9; ++a)
                {
                    if (area[x, y].value == area[a, y].value && area[x, y] != area[a, y])
                    {
                        Debug.Log("gameManager: Sudoku is incorrect (Horizontal) in line: " + (y + 1));
                        return false;
                    }
                }
            }
        }
        return true;
    }



    private void loadArea()
    {
        areaController[] bufor = new areaController[81];

        //Load all area to bufor
        for (int y = 0, i = 0, line = 1; y < 3;)
        {
            for (int x = 0; x < 3; ++x)
            {
                for (int w = 0; w < 3; ++w, ++i)
                {
                    if(line == 1 || line == 4 || line == 7)
                    {
                        bufor[i] = square[x, y].gameObject.transform.GetChild(0).gameObject.transform.GetChild(w).gameObject.GetComponent<areaController>();
                    }
                    else if(line == 2 || line == 5 || line == 8)
                    {
                        bufor[i] = square[x, y].gameObject.transform.GetChild(0).gameObject.transform.GetChild(w+3).gameObject.GetComponent<areaController>();
                    }
                    else if (line == 3 || line == 6 || line == 9)
                    {
                        bufor[i] = square[x, y].gameObject.transform.GetChild(0).gameObject.transform.GetChild(w + 6).gameObject.GetComponent<areaController>();
                    }
                }

                if (x == 2)
                {
                    if (line == 3 || line == 6 || line == 9) ++y;
                    line++;
                }
            }
        }

        //Load area from bufor
        for (int y = 0, i = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9; ++x, ++i)
            {
                area[x, y] = bufor[i];
                Debug.Log(area[x, y] + " : " + area[x, y].gameObject.transform.parent.gameObject.transform.parent.gameObject.name + " -- " + x + " : " + y);
            }
        }
    }
}
