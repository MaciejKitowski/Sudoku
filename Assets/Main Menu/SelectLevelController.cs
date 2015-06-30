using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SelectLevelController : MonoBehaviour 
{
    public bool active;
    public int activeLevel = 0;

    public enum difficult { DIFFICULT_EASY, DIFFICULT_MEDIUM, DIFFICULT_HARD };
    public difficult Difficult;

    private Text bestMoves;
    private Text bestTime;
    private Text selectedLevel;
    private SelectLevelArenaController arena;
    private List<Level> activeDifficult;
    private float touchBeginPosition;
    private float touchEndPosition;
    private float touchDirection;

    Slider slider;

    void Start()
    {
        arena = gameObject.transform.GetComponentInChildren<SelectLevelArenaController>();
        bestTime = gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        bestMoves = gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        selectedLevel = gameObject.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        slider = gameObject.transform.GetChild(9).gameObject.GetComponent<Slider>();
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);

        //Move between levels by touch
        if (Input.GetTouch(0).phase == TouchPhase.Began) touchBeginPosition = Input.GetTouch(0).position.x;

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchEndPosition = Input.GetTouch(0).position.x;
            touchDirection = touchEndPosition - touchBeginPosition;
            if (touchDirection < 0F) buttonNextLevel(); //Right
            if (touchDirection > 0F) buttonPreviousLevel(); //Left
        }
	}

    private void updateLevel()
    {
        if(activeLevel < activeDifficult.Count)
        {
            //Set values on arena
            for (int i = 0; i < 81; ++i)
            {
                if (activeDifficult[activeLevel].getDisplay(i)) arena.setValue(i, activeDifficult[activeLevel].getValue(i).ToString());
                else arena.setValue(i, " ");
            }

            //Set best moves
            if (activeDifficult[activeLevel].bestMoves != 0) bestMoves.text = activeDifficult[activeLevel].bestMoves.ToString();
            else bestMoves.text = "Empty";

            //Set best time
            if(activeDifficult[activeLevel].bestTime != 0)
            {
                int minutes = Mathf.FloorToInt(activeDifficult[activeLevel].bestTime / 60F);
                int seconds = Mathf.FloorToInt(activeDifficult[activeLevel].bestTime - minutes * 60);
                bestTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else bestTime.text = "Empty";

            //Set active selected level
            selectedLevel.text = (activeLevel + 1).ToString() + " / " + activeDifficult.Count.ToString();
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
                    activeDifficult = LevelManager.easyLevels;
                    break;
                case difficult.DIFFICULT_MEDIUM:
                    activeDifficult = LevelManager.mediumLevels;
                    break;
                case difficult.DIFFICULT_HARD:
                    activeDifficult = LevelManager.hardLevels;
                    break;
            }
            slider.maxValue = activeDifficult.Count;
            updateLevel();
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
        gameManager.audio.play();

        gameManager.randomGame = false;
        gameManager.arena.resetAreaValues();
        gameManager.arena.setAreaValues(activeDifficult[activeLevel]);
        gameManager.arena.setActive(true);
        gameManager.endGamePanel.setActive(false);
        gameManager.numpad.hide();
        MainMenuManager.mainMenu.setActive(false);
        setActive(false);
    }

    public void buttonNextLevel()
    {
        Debug.Log("Next level button");
        gameManager.audio.play();

        if (activeLevel < activeDifficult.Count - 1)
        {
            ++activeLevel;
            updateLevel();
        }
        else if (activeLevel == activeDifficult.Count - 1)
        {
            activeLevel = 0;
            updateLevel();
        }
        slider.value = activeLevel + 1;
    }

    public void buttonPreviousLevel()
    {
        Debug.Log("Previous level button");
        gameManager.audio.play();

        if (activeLevel > 0)
        {
            --activeLevel;
            updateLevel();
        }
        else if (activeLevel == 0)
        {
            activeLevel = activeDifficult.Count - 1;
            updateLevel();
        }
        slider.value = activeLevel + 1;
    }

    public void buttonDebugSelectArenaFilled()
    {
        Debug.LogWarning("Select filled arena button");
        gameManager.audio.play();

        gameManager.randomGame = false;
        gameManager.arena.resetAreaValues();
        gameManager.arena.setAreaValuesDEBUG(activeDifficult[activeLevel]);
        gameManager.arena.setActive(true);
        gameManager.endGamePanel.setActive(false);
        gameManager.numpad.hide();
        MainMenuManager.mainMenu.setActive(false);
        setActive(false);
    }

    public void sliderControl()
    {
        activeLevel = (int)slider.value - 1;
        updateLevel();
    }
}
