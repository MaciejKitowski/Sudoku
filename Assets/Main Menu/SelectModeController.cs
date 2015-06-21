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
        setActive(false);
        MainMenuManager.selectLevelPanel.setActive(true, SelectLevelController.difficult.DIFFICULT_EASY);
    }

    public void buttonPreMedium()
    {
        Debug.Log("Predefined Medium button");
        setActive(false);
        MainMenuManager.selectLevelPanel.setActive(true, SelectLevelController.difficult.DIFFICULT_MEDIUM);
    }

    public void buttonPreHard()
    {
        Debug.Log("Predefined Hard button");
        setActive(false);
        MainMenuManager.selectLevelPanel.setActive(true, SelectLevelController.difficult.DIFFICULT_HARD);
    }

    //Buttons - Random
    public void buttonRandEasy()
    {
        Debug.Log("Random Easy button");
        setActive(false);
    }

    public void buttonRandMedium()
    {
        Debug.Log("Random Medium button");
        setActive(false);
    }

    public void buttonRandHard()
    {
        Debug.Log("Random Hard button");
        setActive(false);
    }
}
