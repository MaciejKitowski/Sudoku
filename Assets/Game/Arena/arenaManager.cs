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
        areaController[] buffer = new areaController[81];

        //Load all areas to buffer
        for (int y = 0, i = 0, line = 1; y < 3;)
        {
            for (int x = 0; x < 3; ++x)
            {
                for (int w = 0; w < 3; ++w, ++i)
                {
                    if(line == 1 || line == 4 || line == 7) buffer[i] = square[x, y].getArea(w);
                    else if(line == 2 || line == 5 || line == 8) buffer[i] = square[x, y].getArea(w + 3);
                    else if (line == 3 || line == 6 || line == 9) buffer[i] = square[x, y].getArea(w + 6);
                }

                if (x == 2)
                {
                    if (line == 3 || line == 6 || line == 9) ++y;
                    line++;
                }
            }
        }

        //Load areas from buffer
        for (int y = 0, i = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9; ++x, ++i) area[x, y] = buffer[i];
            //Debug.Log(area[x, y] + " : " + area[x, y].gameObject.transform.parent.gameObject.transform.parent.gameObject.name + " -- " + x + " : " + y);
        }
    }
}
