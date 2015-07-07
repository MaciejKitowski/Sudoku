using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameController : MonoBehaviour 
{
    public bool active;

    private Text timeValue;
    private Text timeValueLast;
    private Text movesValue;
    private Text movesValueLast;

    private Level activeLevel;

    void Awake()
    {
        timeValue = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();
        movesValue = gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<Text>();
        timeValueLast = gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).GetComponent<Text>();
        movesValueLast = gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).GetComponent<Text>();
    }

    public void setActive(bool state)
    {
        gameObject.SetActive(state);
        active = state;
    }

    public void refresh(Level lev)
    {
        gameManager.countTime = false;
        activeLevel = lev;

        timeValue.text = gameManager.transformToTime();
        movesValue.text = gameManager.moves.ToString();

        if(!gameManager.randomGame)
        {
            timeValueLast.transform.parent.gameObject.SetActive(true);
            movesValueLast.transform.parent.gameObject.SetActive(true);
            timeValueLast.text = gameManager.transformToTime(lev.bestTime);
            movesValueLast.text = lev.bestMoves.ToString();
        }
        else
        {
            timeValueLast.transform.parent.gameObject.SetActive(false);
            movesValueLast.transform.parent.gameObject.SetActive(false);
        }
    }

    public void buttonBackToMenu()
    {
        gameManager.audio.play();
        if (activeLevel.bestMoves == 0 || activeLevel.bestMoves > gameManager.moves) activeLevel.bestMoves = gameManager.moves;
        if (activeLevel.bestTime == 0 || activeLevel.bestTime > gameManager.timer) activeLevel.bestTime = gameManager.timer;
        MainMenuManager.stats.updateStats(MainMenuManager.selectLevelPanel.Difficult, true);
        MainMenuManager.mainMenu.setActive(true);
        gameManager.arena.setActive(false);
        gameManager.arena.resetAreaValues();
        gameManager.numpad.hide();
        setActive(false);
    }
}
