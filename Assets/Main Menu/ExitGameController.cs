using UnityEngine;
using System.Collections;

public class ExitGameController : MonoBehaviour 
{
    public bool active;

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
    }
	
    public void setActive(bool state)
    {
        if(state == true)
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

    public void ButtonYes()
    {
        LevelManager.Save();
        Debug.Log("Yes button");
        Application.Quit();
    }

    public void ButtonNo()
    {
        Debug.Log("No button");
        setActive(false);
    }
}
