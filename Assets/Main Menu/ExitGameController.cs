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
        switch(state)
        {
            case true:
                active = true;
                LevelManager.Save();
                gameObject.SetActive(true);
                break;

            case false:
                active = false;
                gameObject.SetActive(false);
                break;
        }
    }

    public void ButtonYes()
    {
        Debug.Log("Yes button");
        Application.Quit();
    }

    public void ButtonNo()
    {
        Debug.Log("No button");
        setActive(false);
    }
}
