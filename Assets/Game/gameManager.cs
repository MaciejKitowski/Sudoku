using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
    public static numpadController numpad;
    public static checkButtonController checkButton;
    public static arenaManager arena;

    public static float timer;
    public static int moves;

    private static bool sudokuIncorrect;
    
	void Awake()
    {
        timer = 0.0f;
        moves = 0;

        numpad = FindObjectOfType<numpadController>();
        checkButton = FindObjectOfType<checkButtonController>();
        arena = FindObjectOfType<arenaManager>();

        numpad.gameObject.SetActive(false);
        checkButton.deactivate();
    }
	
	void Update () 
    {
        timer += Time.deltaTime;
	}

    public static void checkSudoku()
    {
        sudokuIncorrect = false;

        //Check squares
        for (int x = 0; x < 3 && !sudokuIncorrect; ++x)
        {
            for (int y = 0; y < 3 && !sudokuIncorrect; ++y)
            {
                if (!arena.square[x, y].checkSquare() && !sudokuIncorrect)
                {
                    Debug.Log("gameManager: Sudoku is incorrect in square: " + arena.square[x, y].gameObject.name);
                    sudokuIncorrect = true;
                }
            }
        }
    }
}
