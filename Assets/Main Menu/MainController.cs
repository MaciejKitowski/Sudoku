using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour 
{
    public bool active;
    
    void Update()
    {
        if (!MainMenuManager.exitPanel.active && !MainMenuManager.selectModePanel.active && !MainMenuManager.selectLevelPanel.active)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MainMenuManager.exitPanel.setActive(true);
            }
        }
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

    public void buttonPlay()
    {
        if (!MainMenuManager.exitPanel.active)
        {
            Debug.Log("Play game button");
            MainMenuManager.selectModePanel.setActive(true);
        }
    }

    public void buttonResolve()
    {
        if (!MainMenuManager.exitPanel.active)
        {
            Debug.Log("Resolve sudoku button");
        }
    }

    public void buttonStatistics()
    {
        if (!MainMenuManager.exitPanel.active)
        {
            Debug.Log("Statistics button");
        }
    }

    public void buttonHowTo()
    {
        if (!MainMenuManager.exitPanel.active)
        {
            Debug.Log("How To button");
        }
    }

    public void buttonExitGame()
    {
        Debug.Log("Exit Game button");
        MainMenuManager.exitPanel.setActive(true);
    }

    public void buttonDEBUGnewLevel()
    {
        Debug.LogWarning("[DEBUG] Add new levels button");
        MainMenuManager.addLevels.setActive(true);
        MainMenuManager.addLevels.reset();
    }
}
