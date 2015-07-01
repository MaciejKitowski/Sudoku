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
            gameManager.audio.play();
            MainMenuManager.selectModePanel.setActive(true);
        }
    }

    public void buttonResolve()
    {
        if (!MainMenuManager.exitPanel.active)
        {
            Debug.Log("Resolve sudoku button");
            gameManager.audio.play();
        }
    }

    public void buttonStatistics()
    {
        if (!MainMenuManager.exitPanel.active)
        {
            Debug.Log("Statistics button");
            gameManager.audio.play();
        }
    }

    public void buttonHowTo()
    {
        if (!MainMenuManager.exitPanel.active)
        {
            Debug.Log("How To button");
            gameManager.audio.play();
        }
    }

    public void buttonExitGame()
    {
        Debug.Log("Exit Game button");
        gameManager.audio.play();
        MainMenuManager.exitPanel.setActive(true);
    }

    public void buttonDEBUGnewLevel()
    {
        Debug.LogWarning("[DEBUG] Add new levels button");
        gameManager.audio.play();
        MainMenuManager.addLevels.setActive(true);
        MainMenuManager.addLevels.reset();
    }

    public void buttonSettings()
    {
        Debug.Log("Settings button");
        gameManager.audio.play();
        MainMenuManager.settings.setActive(true);
    }
}
