using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class areaController : MonoBehaviour 
{
    public int value;

    private Text valueText;
	
	void Start () 
    {
        valueText = gameObject.GetComponentInChildren<Text>();
        valueText.text = " ";

        value = 0;
	}
	
	
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        if(!gameManager.numpad.isDisplayed())
        {
            Debug.Log(gameObject.transform.parent.transform.parent.name + " - " + gameObject.name);

            gameManager.numpad.setSelectedArea(gameObject.GetComponent<areaController>());
            gameManager.numpad.display();
        }
    }

    public void setValue(int val)
    {
        value = val;

        if (val == 0) valueText.text = " ";
        else valueText.text = val.ToString();
    }
}
