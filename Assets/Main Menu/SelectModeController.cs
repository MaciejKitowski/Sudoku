using UnityEngine;
using System.Collections;

public class SelectModeController : MonoBehaviour 
{
    public bool active;
	
	void Start () 
    {
	
	}
	
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
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

    //Buttons - Predefined
    public void buttonPreEasy()
    {
        Debug.Log("Predefined Easy button");
    }

    public void buttonPreMedium()
    {
        Debug.Log("Predefined Medium button");
    }

    public void buttonPreHard()
    {
        Debug.Log("Predefined Hard button");
    }

    //Buttons - Random
    public void buttonRandEasy()
    {
        Debug.Log("Random Easy button");
    }

    public void buttonRandMedium()
    {
        Debug.Log("Random Medium button");
    }

    public void buttonRandHard()
    {
        Debug.Log("Random Hard button");
    }
}
