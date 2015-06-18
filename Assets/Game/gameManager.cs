using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
    public static numpadController numpad;
    public static checkButtonController checkButton;
    public static arenaManager arena;

    public static float timer;
    public static int moves;
    
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

        if (arena.checkEmpty()) checkButton.activate();
        else checkButton.deactivate();
	}

    public static void resetTimer()
    {
        timer = 0F;
    }

    public static void checkSudoku()
    {
        if (!arena.checkHorizontal() || !arena.checkVertical() || !arena.checkSquare())
        {
            Debug.Log("--- Sudoku is incorrect ---");
        }
        else
        {
            Debug.Log("--- SUDOKU IS CORRECT ---");
        }         
    }
}
