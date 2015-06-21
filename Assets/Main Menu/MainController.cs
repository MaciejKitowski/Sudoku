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
        if (state == true)
        {
            gameObject.SetActive(true);
            active = true;
        }
        else
        {
            gameObject.SetActive(false);
            active = false;
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
}
