using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour 
{
    public bool active;
    
    private MainMenuManager manager;

    void Start()
    {
        manager = gameObject.transform.GetComponentInParent<MainMenuManager>();
    }

    void Update()
    {
        if (!manager.exitPanel.active && !manager.selectModePanel.active)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                manager.exitPanel.setActive(true);
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
        if (!manager.exitPanel.active)
        {
            Debug.Log("Play game button");
            manager.selectModePanel.setActive(true);
        }
    }

    public void buttonResolve()
    {
        if (!manager.exitPanel.active)
        {
            Debug.Log("Resolve sudoku button");
        }
    }

    public void buttonStatistics()
    {
        if (!manager.exitPanel.active)
        {
            Debug.Log("Statistics button");
        }
    }

    public void buttonHowTo()
    {
        if(!manager.exitPanel.active)
        {
            Debug.Log("How To button");
        }
    }

    public void buttonExitGame()
    {
        Debug.Log("Exit Game button");
        manager.exitPanel.setActive(true);
    }
}
