using UnityEngine;
using System.Collections;

public class SelectModeController : MonoBehaviour 
{
    public bool active;

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
	}

    public void setActive(bool state)
    {
        switch(state)
        {
            case true:
                active = true;
                gameObject.SetActive(true);
                break;
            case false:
                active = false;
                gameObject.SetActive(false);
                break;
        }
    }

    //Buttons - Predefined
    public void buttonPreEasy()
    {
        Debug.Log("Predefined Easy button");
        gameManager.audio.play();
        setActive(false);
        MainMenuManager.selectLevelPanel.setActive(true, SelectLevelController.difficult.DIFFICULT_EASY);
    }

    public void buttonPreMedium()
    {
        Debug.Log("Predefined Medium button");
        gameManager.audio.play();
        setActive(false);
        MainMenuManager.selectLevelPanel.setActive(true, SelectLevelController.difficult.DIFFICULT_MEDIUM);
    }

    public void buttonPreHard()
    {
        Debug.Log("Predefined Hard button");
        gameManager.audio.play();
        setActive(false);
        MainMenuManager.selectLevelPanel.setActive(true, SelectLevelController.difficult.DIFFICULT_HARD);
    }

    //Buttons - Random
    public void buttonRandEasy()
    {
        Debug.Log("Random Easy button");
        gameManager.audio.play();
        gameManager.arena.resetAreaValues();
        gameManager.arena.setAreaValues(LevelManager.easyLevels[Random.Range(0,LevelManager.easyLevels.Count-1)]);
        gameManager.arena.setActive(true);
        MainMenuManager.mainMenu.setActive(false);
        setActive(false);
    }

    public void buttonRandMedium()
    {
        Debug.Log("Random Medium button");
        gameManager.audio.play();
        gameManager.randomGame = true;
        gameManager.arena.resetAreaValues();
        gameManager.arena.setAreaValues(LevelManager.mediumLevels[Random.Range(0, LevelManager.mediumLevels.Count - 1)]);
        gameManager.arena.setActive(true);
        MainMenuManager.mainMenu.setActive(false);
        setActive(false);
    }

    public void buttonRandHard()
    {
        Debug.Log("Random Hard button");
        gameManager.audio.play();
        gameManager.randomGame = true;
        gameManager.arena.resetAreaValues();
        gameManager.arena.setAreaValues(LevelManager.hardLevels[Random.Range(0, LevelManager.hardLevels.Count - 1)]);
        gameManager.arena.setActive(true);
        MainMenuManager.mainMenu.setActive(false);
        setActive(false);
    }
}
