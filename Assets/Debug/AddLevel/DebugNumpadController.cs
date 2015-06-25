using UnityEngine;
using System.Collections;

public class DebugNumpadController : MonoBehaviour 
{
    public enum buttonType { BUTTON_NUMBER, BUTTON_BACK, BUTTON_CLEAR }
    public DebugAreaController selectedArea;

    public bool isDisplayed()
    {
        if (selectedArea == null) return false;
        return true;
    }

    public void setSelectedArea(DebugAreaController area)
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
