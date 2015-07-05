using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
    public static numpadController numpad;
    public static checkButtonController checkButton;
    public static arenaManager arena;
    public static EndGameController endGamePanel;

    public static float timer;
    public static int moves;

    public static bool randomGame;
    public static bool countTime;

    public static audioController audio;
    
	void Awake()
    {
        timer = 0.0f;
        moves = 0;

        numpad = FindObjectOfType<numpadController>();
        checkButton = FindObjectOfType<checkButtonController>();
        arena = FindObjectOfType<arenaManager>();
        endGamePanel = FindObjectOfType<EndGameController>();
        audio = FindObjectOfType<audioController>();

        numpad.gameObject.SetActive(false);
        endGamePanel.setActive(false);
        checkButton.deactivate();

        LevelManager.Load();
    }
	
	void Update () 
    {
        if (countTime)timer += Time.deltaTime;

        if (arena.checkEmpty()) checkButton.activate();
        else checkButton.deactivate();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            arena.setActive(false);
            MainMenuManager.stats.updateStats(MainMenuManager.selectLevelPanel.Difficult);
            MainMenuManager.mainMenu.setActive(true);
        }
	}

    public static void resetTimer()
    {
        countTime = true;
        timer = 0F;
    }

    public static void checkSudoku()
    {
        if (!arena.checkHorizontal() || !arena.checkVertical() || !arena.checkSquare())
        {
            Debug.Log("--- Sudoku is incorrect ---");
            audio.play(audioController.soundType.SOUND_BADSUDOKU);
        }
        else
        {
            Debug.Log("--- SUDOKU IS CORRECT ---");
            audio.play(audioController.soundType.SOUND_GOODSUDOKU);
            endGamePanel.setActive(true);
            endGamePanel.refresh(arena.getActiveLevel());
        }         
    }
}
