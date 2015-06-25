using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugAddingLevelsController : MonoBehaviour 
{
    public bool active;
    public bool isConstant;

    public DebugNumpadController numpad;

    private Button constantButton;
    

    void Awake()
    {
        constantButton = gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
        numpad = gameObject.transform.GetComponentInChildren<DebugNumpadController>();
        numpad.hide();
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


    public void buttonToggleConstant()
    {
        Debug.LogWarning("[DEBUG] - Toggle constant mode");

        if(!numpad.isDisplayed())
        {
            if (isConstant)
            {
                isConstant = false;
                constantButton.image.color = Color.white;
            }
            else
            {
                isConstant = true;
                constantButton.image.color = Color.red;
            }
        }
    }

    public void buttonBack()
    {
        Debug.LogWarning("[DEBUG] - Back to menu");
        
        if(!numpad.isDisplayed())
        {
            setActive(false);
        }
    }

    public void buttonEasy()
    {
        Debug.LogWarning("[DEBUG] - Save to easy difficult");

        if(!numpad.isDisplayed())
        {

        }
    }

    public void buttonMedium()
    {
        Debug.LogWarning("[DEBUG] - Save to medium difficult");

        if(!numpad.isDisplayed())
        {

        }
    }

    public void buttonHard()
    {
        Debug.LogWarning("[DEBUG] - Save to hard difficult");

        if(!numpad.isDisplayed())
        {

        }
    }
}
