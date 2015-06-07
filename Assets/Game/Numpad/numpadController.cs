using UnityEngine;
using System.Collections;

public class numpadController : MonoBehaviour 
{
    public enum buttonType { BUTTON_NUMBER, BUTTON_BACK, BUTTON_CLEAR }
    public areaController selectedArea;

	void Start ()
    {
	
	}
	

	void Update ()
    {
	
	}




    public bool isDisplayed()
    {
        if (selectedArea == null) return false;
        return true;
    }

    public void setSelectedArea(areaController area)
    {
        selectedArea = area;
    }

    public void display()
    {
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
        selectedArea = null;
    }
}
