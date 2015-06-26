using UnityEngine;
using System.Collections;

public class arenaManager : MonoBehaviour 
{
    public squareController[,] square;
    public areaController[,] area;

    private Level activeLevel;
	
	void Start () 
    {
        square = new squareController[3, 3];
        area = new areaController[9, 9];

        for (int y = 0, i = 0; y < 3; ++y)
        {
            for (int x = 0; x < 3; ++x, ++i) square[x,y] = gameObject.transform.GetChild(i).gameObject.GetComponent<squareController>();
        }

        loadArea();
        setActive(false);
	}

    public bool checkEmpty()
    {
        for (int y = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9; ++x)
            {
                if (area[x, y].value == 0) return false;
            }
        }
        return true;
    }

    public void resetAreaValues()
    {
        gameManager.moves = 0;
        gameManager.resetTimer();
        for(int y = 0, i = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9 && i < 81; ++x, ++i) area[x, y].reset();
        }
    }

    public void setAreaValues(Level level)
    {
        activeLevel = level;

        for(int y = 0, i = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9 && i < 81; ++x, ++i) if (activeLevel.getDisplay(i)) area[x, y].setConstValue(activeLevel.getValue(i));
        }
    }

    public void setAreaValuesDEBUG(Level level)
    {
        activeLevel = level;

        for (int y = 0, i = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9 && i < 81; ++x, ++i)
            {
                if (activeLevel.getDisplay(i)) area[x, y].setConstValue(activeLevel.getValue(i));
                else area[x, y].setValue(activeLevel.getValue(i));
            }
        }
    }

    public void setActive(bool state)
    {
        switch(state)
        {
            case true:
                gameObject.transform.parent.gameObject.SetActive(true);
                break;
            case false:
                gameObject.transform.parent.gameObject.SetActive(false);
                break;
        }
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

    public bool checkVertical()
    {
        for (int x = 0; x < 9; ++x)
        {
            for (int y = 0; y < 9; ++y)
            {
                for (int b = 0; b < 9; ++b)
                {
                    if (area[x, y].value == area[x, b].value && area[x, y] != area[x, b])
                    {
                        Debug.Log("gameManager: Sudoku is incorrect (Vertical) in line: " + (x + 1));
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public bool checkSquare()
    {
        for (int y = 0; y < 3; ++y)
        {
            for (int x = 0; x < 3; ++x) if (!square[x, y].checkSquare()) return false;
        }
        return true;
    }

    public Level getActiveLevel()
    {
        return activeLevel;
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

        for (int y = 0, i = 0; y < 9; ++y) for (int x = 0; x < 9; ++x, ++i) area[x, y] = buffer[i]; //Load areas from buffer
    }
}
