using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class areaController : MonoBehaviour 
{
    public int value;
    public bool canEdit = true;

    private Text valueText;
	
	void Start () 
    {
        valueText = gameObject.GetComponentInChildren<Text>();
        valueText.text = " ";

        value = 0;
	}
	
    void OnMouseDown()
    {
        if(!gameManager.numpad.isDisplayed() && canEdit)
        {
            Debug.Log(gameObject.transform.parent.transform.parent.name + " - " + gameObject.name);

            gameManager.numpad.setSelectedArea(gameObject.GetComponent<areaController>());
            gameManager.numpad.display();
        }
    }

    public void reset()
    {
        value = 0;
        canEdit = true;
        valueText.text = " ";
    }

    public void setValue(int val)
    {
        value = val;

        if (val == 0) valueText.text = " ";
        else valueText.text = val.ToString();
    }

    public void setConstValue(int val)
    {
        value = val;
        canEdit = false;
        gameObject.GetComponent<RawImage>().color = new Color32(221,221,221,255);
        valueText.text = val.ToString();
    }
}
