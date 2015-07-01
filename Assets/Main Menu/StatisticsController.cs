using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatisticsController : MonoBehaviour 
{
    public bool active;

    public float totalTime;
    public int totalMoves;

    public float easyTotalTime, mediumTotalTime, hardTotalTime;
    public int easyTotalMoves, mediumTotalMoves, hardTotalMoves;
    public int easyTotalWins, mediumTotalWins, hardTotalWins;

    private Text totalTimeTxt, totalMovesTxt;
    private Text[] easyLevels, mediumLevels, hardLevels;
	
	void Awake () 
    {
        easyLevels = new Text[3];
        mediumLevels = new Text[3];
        hardLevels = new Text[3];

        totalTimeTxt = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        totalMovesTxt = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        for(int i = 0; i < 3; ++i)
        {
            easyLevels[i] = gameObject.transform.GetChild(i + 3).gameObject.transform.GetChild(0).GetComponent<Text>();
            mediumLevels[i] = gameObject.transform.GetChild(i + 6).gameObject.transform.GetChild(0).GetComponent<Text>();
            hardLevels[i] = gameObject.transform.GetChild(i + 9).gameObject.transform.GetChild(0).GetComponent<Text>();
        }

        if (PlayerPrefs.HasKey("CheckStatsPlayerPrefs")) loadFromPlayerPrefs();
        else saveToPlayerPrefs();
	}

    public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);

        if(state == true)
        {
            int minutes = Mathf.FloorToInt(totalTime / 60F);
            int seconds = Mathf.FloorToInt(totalTime - minutes * 60);
            totalTimeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            totalMovesTxt.text = totalMoves.ToString();

            minutes = Mathf.FloorToInt(easyTotalTime / 60F);
            seconds = Mathf.FloorToInt(easyTotalTime - minutes * 60);
            easyLevels[0].text = string.Format("{0:00}:{1:00}", minutes, seconds);
            easyLevels[1].text = easyTotalWins.ToString();
            easyLevels[2].text = easyTotalMoves.ToString();

            minutes = Mathf.FloorToInt(mediumTotalTime / 60F);
            seconds = Mathf.FloorToInt(mediumTotalTime - minutes * 60);
            mediumLevels[0].text = string.Format("{0:00}:{1:00}", minutes, seconds);
            mediumLevels[1].text = mediumTotalWins.ToString();
            mediumLevels[2].text = mediumTotalMoves.ToString();

            minutes = Mathf.FloorToInt(hardTotalTime / 60F);
            seconds = Mathf.FloorToInt(hardTotalTime - minutes * 60);
            hardLevels[0].text = string.Format("{0:00}:{1:00}", minutes, seconds);
            hardLevels[1].text = hardTotalWins.ToString();
            hardLevels[2].text = hardTotalMoves.ToString();
        }
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
        totalTime = PlayerPrefs.GetFloat("totalTime");
        totalMoves = PlayerPrefs.GetInt("totalMoves");

        easyTotalTime = PlayerPrefs.GetFloat("easyTotalTime");
        easyTotalMoves = PlayerPrefs.GetInt("easyTotalMoves");
        easyTotalWins = PlayerPrefs.GetInt("easyTotalWins");

        mediumTotalTime = PlayerPrefs.GetFloat("mediumTotalTime");
        mediumTotalMoves = PlayerPrefs.GetInt("mediumTotalMoves");
        mediumTotalWins = PlayerPrefs.GetInt("mediumTotalWins");

        hardTotalTime = PlayerPrefs.GetFloat("hardTotalTime");
        hardTotalMoves = PlayerPrefs.GetInt("hardTotalMoves");
        hardTotalWins = PlayerPrefs.GetInt("hardTotalWins");
    }

    private void saveToPlayerPrefs()
    {
        PlayerPrefs.SetString("CheckStatsPlayerPrefs", "Checked");
        PlayerPrefs.SetFloat("totalTime", totalTime);
        PlayerPrefs.SetInt("totalMoves", totalMoves);

        PlayerPrefs.SetFloat("easyTotalTime", easyTotalTime);
        PlayerPrefs.SetInt("easyTotalMoves", easyTotalMoves);
        PlayerPrefs.SetInt("easyTotalWins", easyTotalWins);

        PlayerPrefs.SetFloat("mediumTotalTime", mediumTotalTime);
        PlayerPrefs.SetInt("mediumTotalMoves", mediumTotalMoves);
        PlayerPrefs.SetInt("mediumTotalWins", mediumTotalWins);

        PlayerPrefs.SetFloat("hardTotalTime", hardTotalTime);
        PlayerPrefs.SetInt("hardTotalMoves", hardTotalMoves);
        PlayerPrefs.SetInt("hardTotalWins", hardTotalWins);
    }
}
