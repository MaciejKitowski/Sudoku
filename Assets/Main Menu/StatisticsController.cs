using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatisticsController : MonoBehaviour 
{
    public bool active;

    public float time;
    public int moves;
    private Text timeTxt, movesTxt;

    private struct levelDetail
    {
        public float time;
        public int moves, wins;
        public Text timeTxt, winsTxt, movesTxt;
    }
    private levelDetail easy, medium, hard;

    /*public float easyTotalTime, mediumTotalTime, hardTotalTime;
    public int easyTotalMoves, mediumTotalMoves, hardTotalMoves;
    public int easyTotalWins, mediumTotalWins, hardTotalWins;*/

    //private Text[] easyLevels, mediumLevels, hardLevels;
	
	void Awake () 
    {
        /*easyLevels = new Text[3];
        mediumLevels = new Text[3];
        hardLevels = new Text[3];*/

        timeTxt = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        movesTxt = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        easy.timeTxt = gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        easy.winsTxt = gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        easy.movesTxt = gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        medium.timeTxt = gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        medium.winsTxt = gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        medium.movesTxt = gameObject.transform.GetChild(4).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        hard.timeTxt = gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        hard.winsTxt = gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        hard.movesTxt = gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        if (PlayerPrefs.HasKey("CheckStatsPlayerPrefs")) loadFromPlayerPrefs();
        else saveToPlayerPrefs();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
    }

    public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);
        if (state) updateTxt();
    }

    public void updateStats(SelectLevelController.difficult Difficult, bool isWon = false)
    {
        moves += gameManager.moves;
        time += gameManager.timer;

        switch (Difficult)
        {
            case SelectLevelController.difficult.DIFFICULT_EASY:
                easy.moves += gameManager.moves;
                easy.time += gameManager.timer;
                if (isWon) easy.wins++;
                break;
            case SelectLevelController.difficult.DIFFICULT_MEDIUM:
                medium.moves += gameManager.moves;
                medium.time += gameManager.timer;
                if (isWon) medium.wins++;
                break;
            case SelectLevelController.difficult.DIFFICULT_HARD:
                hard.moves += gameManager.moves;
                hard.time += gameManager.timer;
                if (isWon) hard.wins++;
                break;
        }
    }

    private void updateTxt()
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        timeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        movesTxt.text = moves.ToString();

        minutes = Mathf.FloorToInt(easy.time / 60F);
        seconds = Mathf.FloorToInt(easy.time - minutes * 60);
        easy.timeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        easy.winsTxt.text = easy.wins.ToString();
        easy.movesTxt.text = easy.moves.ToString();

        minutes = Mathf.FloorToInt(medium.time / 60F);
        seconds = Mathf.FloorToInt(medium.time - minutes * 60);
        medium.timeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        medium.winsTxt.text = medium.wins.ToString();
        medium.movesTxt.text = medium.moves.ToString();

        minutes = Mathf.FloorToInt(hard.time / 60F);
        seconds = Mathf.FloorToInt(hard.time - minutes * 60);
        hard.timeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        hard.winsTxt.text = hard.wins.ToString();
        hard.movesTxt.text = hard.moves.ToString();
    }

    public void buttonBackToMenu()
    {
        Debug.Log("Back to menu button");
        gameManager.audio.play();
        saveToPlayerPrefs();
        setActive(false);
    }

    private void loadFromPlayerPrefs()
    {
        time = PlayerPrefs.GetFloat("totalTime");
        moves = PlayerPrefs.GetInt("totalMoves");

        /*easyTotalTime = PlayerPrefs.GetFloat("easyTotalTime");
        easyTotalMoves = PlayerPrefs.GetInt("easyTotalMoves");
        easyTotalWins = PlayerPrefs.GetInt("easyTotalWins");

        mediumTotalTime = PlayerPrefs.GetFloat("mediumTotalTime");
        mediumTotalMoves = PlayerPrefs.GetInt("mediumTotalMoves");
        mediumTotalWins = PlayerPrefs.GetInt("mediumTotalWins");

        hardTotalTime = PlayerPrefs.GetFloat("hardTotalTime");
        hardTotalMoves = PlayerPrefs.GetInt("hardTotalMoves");
        hardTotalWins = PlayerPrefs.GetInt("hardTotalWins");*/
    }

    private void saveToPlayerPrefs()
    {
        PlayerPrefs.SetString("CheckStatsPlayerPrefs", "Checked");
        PlayerPrefs.SetFloat("totalTime", time);
        PlayerPrefs.SetInt("totalMoves", moves);

        /*PlayerPrefs.SetFloat("easyTotalTime", easyTotalTime);
        PlayerPrefs.SetInt("easyTotalMoves", easyTotalMoves);
        PlayerPrefs.SetInt("easyTotalWins", easyTotalWins);

        PlayerPrefs.SetFloat("mediumTotalTime", mediumTotalTime);
        PlayerPrefs.SetInt("mediumTotalMoves", mediumTotalMoves);
        PlayerPrefs.SetInt("mediumTotalWins", mediumTotalWins);

        PlayerPrefs.SetFloat("hardTotalTime", hardTotalTime);
        PlayerPrefs.SetInt("hardTotalMoves", hardTotalMoves);
        PlayerPrefs.SetInt("hardTotalWins", hardTotalWins);*/
    }
}
