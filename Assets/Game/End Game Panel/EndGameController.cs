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

        int minutes = Mathf.FloorToInt(gameManager.timer / 60F);
        int seconds = Mathf.FloorToInt(gameManager.timer - minutes * 60);

        timeValue.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        movesValue.text = gameManager.moves.ToString();

        minutes = Mathf.FloorToInt(lev.bestTime / 60F);
        seconds = Mathf.FloorToInt(lev.bestTime - minutes * 60);

        timeValueLast.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        movesValueLast.text = lev.bestMoves.ToString();
    }

    public void buttonBackToMenu()
    {
        gameManager.audio.play();
        MainMenuManager.mainMenu.setActive(true);
        gameManager.arena.setActive(false);
    }



}
