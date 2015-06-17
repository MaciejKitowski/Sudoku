using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectLevelController : MonoBehaviour 
{
    public bool active;
    public int activeLevel = 0;

    public enum difficult { DIFFICULT_EASY, DIFFICULT_MEDIUM, DIFFICULT_HARD };
    public difficult Difficult;

    private Text bestMoves;
    private Text bestTime;
    private SelectLevelArenaController arena;

    void Start()
    {
        arena = gameObject.transform.GetComponentInChildren<SelectLevelArenaController>();
        bestMoves = gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        bestTime = gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
	}

    private void updateEasyLevel()
    {
        if(activeLevel < LevelManager.easyLevels.Count)
        {
            //Set values on arena
            for (int i = 0; i < 81; ++i)
            {
                if (LevelManager.easyLevels[activeLevel].displayValue[i]) arena.setValue(i, LevelManager.easyLevels[activeLevel].arenaValue[i].ToString());
                else arena.setValue(i, " ");
            }

            //Set best moves
            if (LevelManager.easyLevels[activeLevel].bestMoves != 0) bestMoves.text = LevelManager.easyLevels[activeLevel].bestMoves.ToString();
            else bestMoves.text = "Empty";

            //Set best time
            if (LevelManager.easyLevels[activeLevel].bestTime != 0)
            {
                int minutes = Mathf.FloorToInt(LevelManager.easyLevels[activeLevel].bestTime / 60F);
                int seconds = Mathf.FloorToInt(LevelManager.easyLevels[activeLevel].bestTime - minutes * 60);
                bestTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else bestTime.text = "Empty";
        }
    }

    public void setActive(bool state, difficult Diff = difficult.DIFFICULT_EASY)
    {
        if (state == true)
        {
            gameObject.SetActive(true);
            activeLevel = 0;
            Difficult = Diff;
            active = true;

            switch(Difficult)
            {
                case difficult.DIFFICULT_EASY:
                    updateEasyLevel();
                    break;
                case difficult.DIFFICULT_MEDIUM:
                    //updateMediumLevel();
                    break;
                case difficult.DIFFICULT_HARD:
                    //updateHardLevel();
                    break;
            }
        }
        else
        {
            gameObject.SetActive(false);
            active = false;
        }
    }

    public void buttonSelect()
    {
        Debug.Log("Select button");
    }

    public void buttonNextLevel()
    {
        Debug.Log("Next level button");

        switch(Difficult)
        {
            case difficult.DIFFICULT_EASY:
                if(activeLevel < LevelManager.easyLevels.Count - 1)
                {
                    ++activeLevel;
                    updateEasyLevel();
                }
                break;

            case difficult.DIFFICULT_MEDIUM:
                if (activeLevel < LevelManager.mediumLevels.Count - 1)
                {
                    ++activeLevel;
                    //updateMediumLevel();
                }
                break;

            case difficult.DIFFICULT_HARD:
                if (activeLevel < LevelManager.hardLevels.Count - 1)
                {
                    ++activeLevel;
                    //updateHardLevel();
                }
                break;
        }
    }

    public void buttonPreviousLevel()
    {
        Debug.Log("Previous level button");

        if (activeLevel > 0)
        {
            --activeLevel;

            switch (Difficult)
            {
                case difficult.DIFFICULT_EASY:
                    updateEasyLevel();
                    break;
                case difficult.DIFFICULT_MEDIUM:
                    //updateMediumLevel();
                    break;
                case difficult.DIFFICULT_HARD:
                    //updateHardLevel();
                    break;
            }
        }
    }
}
