using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugNumpadButtonController : MonoBehaviour 
{
    public DebugNumpadController.buttonType type;
    public int buttonValue;

    private DebugNumpadController numpad;
    private DebugAddingLevelsController manager;

    void Start()
    {
        manager = gameObject.transform.parent.GetComponentInParent<DebugAddingLevelsController>();
        numpad = gameObject.transform.parent.GetComponent<DebugNumpadController>();
        if (type == DebugNumpadController.buttonType.BUTTON_NUMBER && buttonValue == 0) Debug.LogError("Numpad Button: " + gameObject.name + " - Bad buttonValue");
    }

    void OnMouseDown()
    {
        if (type == DebugNumpadController.buttonType.BUTTON_NUMBER)
        {
            Debug.Log("Numpad Button: Set value: " + buttonValue);

            if (manager.isConstant) numpad.selectedArea.setConstValue(buttonValue);
            else numpad.selectedArea.setValue(buttonValue);

            numpad.hide();
        }
        else
        {
            if (type == DebugNumpadController.buttonType.BUTTON_CLEAR)
            {
                Debug.Log("Numpad Button: Clear value");
                numpad.selectedArea.reset();
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
