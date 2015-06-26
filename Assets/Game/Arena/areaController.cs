using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class areaController : MonoBehaviour 
{
    public int value;
    public bool canEdit = true;

    public enum arenaType { ARENA_GAME, ARENA_ADDLEVEL };
    public arenaType areaType;

    private Text valueText;
	
	void Awake() 
    {
        valueText = gameObject.GetComponentInChildren<Text>();
        valueText.text = " ";

        value = 0;
	}
	
    void OnMouseDown()
    {
        if(areaType == arenaType.ARENA_GAME)
        {
            if (!gameManager.numpad.isDisplayed() && canEdit)
            {
                Debug.Log(gameObject.transform.parent.transform.parent.name + " - " + gameObject.name);

                gameManager.numpad.setSelectedArea(gameObject.GetComponent<areaController>());
                gameManager.numpad.display();
            }
        }
        else if(areaType == arenaType.ARENA_ADDLEVEL)
        {
            if (!MainMenuManager.addLevels.numpad.isDisplayed())
            {
                Debug.Log(gameObject.transform.parent.transform.parent.name + " - " + gameObject.name);

                if ((value == 0) || (MainMenuManager.addLevels.isConstant && !canEdit) || (!MainMenuManager.addLevels.isConstant && canEdit))
                {
                    MainMenuManager.addLevels.numpad.setSelectedArea(gameObject.GetComponent<areaController>());
                    MainMenuManager.addLevels.numpad.display();
                }
            }
        }
    }

    public void reset()
    {
        value = 0;
        canEdit = true;
        valueText.text = " ";
        gameObject.GetComponent<RawImage>().color = Color.white;
    }

    public void setValue(int val)
    {
        value = val;

        if (val == 0) valueText.text = " ";
        else valueText.text = val.ToString();
        gameObject.GetComponent<RawImage>().color = Color.white;
    }

    public void setConstValue(int val)
    {
        value = val;
        canEdit = false;
        gameObject.GetComponent<RawImage>().color = Color.gray;
        valueText.text = val.ToString();
    }
}
