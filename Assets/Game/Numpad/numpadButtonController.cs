using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class numpadButtonController : MonoBehaviour 
{
    public numpadController.buttonType type;
    public int buttonValue;

    private numpadController numpad;
    
	
	void Start () 
    {
        numpad = gameObject.transform.parent.transform.parent.GetComponent<numpadController>();
        if (type == numpadController.buttonType.BUTTON_NUMBER && buttonValue == 0) Debug.LogError("Numpad Button: " + gameObject.name + " - Bad buttonValue");
	}
	
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        if(type == numpadController.buttonType.BUTTON_NUMBER)
        {
            Debug.Log("Numpad Button: Set value: " + buttonValue);
            numpad.selectedArea.setValue(buttonValue);
            numpad.hide();
        }
        else
        {
            if(type == numpadController.buttonType.BUTTON_CLEAR)
            {
                Debug.Log("Numpad Button: Clear value");
                numpad.selectedArea.setValue(0);
                numpad.hide();
            }
            else
            {
                Debug.Log("Numpad Button: Back button");
                numpad.hide();
            }
        }
    }
}
