using UnityEngine;
using UnityEngine.UI;
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

    private static Text timerTxt;
    private static Text movesTxt;
    
	void Awake()
    {
        timer = 0F;
        moves = 0;

        numpad = FindObjectOfType<numpadController>();
        checkButton = FindObjectOfType<checkButtonController>();
        arena = FindObjectOfType<arenaManager>();
        endGamePanel = FindObjectOfType<EndGameController>();
        audio = FindObjectOfType<audioController>();

        timerTxt = GameObject.FindGameObjectWithTag("Timer display").gameObject.GetComponent<Text>();
        movesTxt = GameObject.FindGameObjectWithTag("Moves display").gameObject.GetComponent<Text>();
        
        numpad.gameObject.SetActive(false);
        endGamePanel.setActive(false);
        checkButton.deactivate();

        LevelManager.Load();
    }
	
	void Update () 
    {
        if (countTime)
        {
            timer += Time.deltaTime;
            timerTxt.text = transformToTime(timer);
            movesTxt.text = moves.ToString();
        }

        if (arena.checkEmpty()) checkButton.activate();
        else checkButton.deactivate();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            arena.setActive(false);
            MainMenuManager.stats.updateStats(MainMenuManager.selectLevelPanel.Difficult);
            MainMenuManager.mainMenu.setActive(true);
        }
	}

    public static string transformToTime(float time = 0)
    {
        if (time == 0) time = timer;
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
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
