using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugAreaController : MonoBehaviour 
{
    public int value;
    public bool canEdit = true;

    private Text valueText;
    private DebugAddingLevelsController manager;

    void Awake()
    {
        manager = gameObject.transform.GetComponentInParent<DebugAddingLevelsController>();
        valueText = gameObject.GetComponentInChildren<Text>();
        valueText.text = " ";

        value = 0;
    }

    void OnMouseDown()
    {
        if (!manager.numpad.isDisplayed())
        {
            Debug.Log(gameObject.transform.parent.transform.parent.name + " - " + gameObject.name);

            manager.numpad.setSelectedArea(gameObject.GetComponent<DebugAreaController>());
            manager.numpad.display();
        }
    }

    public void reset()
    {
        value = 0;
        canEdit = true;
        valueText.text = " ";
        gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
    }

    public void setValue(int val)
    {
        value = val;

        canEdit = true;
        gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
        if (val == 0) valueText.text = " ";
        else valueText.text = val.ToString();
    }

    public void setConstValue(int val)
    {
        value = val;
        canEdit = false;
        gameObject.GetComponent<RawImage>().color = Color.gray;
        valueText.text = val.ToString();
    }
}
