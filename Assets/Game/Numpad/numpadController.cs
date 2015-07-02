using UnityEngine;
using System.Collections;

public class numpadController : MonoBehaviour 
{
    public enum buttonType { BUTTON_NUMBER, BUTTON_BACK, BUTTON_CLEAR }
    public areaController selectedArea;


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

        switch(Settings.numpadPos)
        {
            case Settings.numpadPosition.POS_LEFT:
                gameObject.transform.localPosition = new Vector3(-90F, 55F, 0F);
                //gameObject.transform.position = new Vector3(-90F, 0F, 0F);
                break;

            case Settings.numpadPosition.POS_CENTER:
                gameObject.transform.localPosition = new Vector3(0F, 55F, 0F);
                //gameObject.transform.position = new Vector3(0F, 0F, 0F);
                break;

            case Settings.numpadPosition.POS_RIGHT:
                gameObject.transform.localPosition = new Vector3(90F, 55F, 0F);
                //gameObject.transform.position = new Vector3(90F, 0F, 0F);
                break;

            case Settings.numpadPosition.POS_DOWN_LEFT:
                gameObject.transform.localPosition = new Vector3(-90F, -220F, 0F);
                //gameObject.transform.position = new Vector3(-90F, -220F, 0F);
                break;

            case Settings.numpadPosition.POS_DOWN_CENTER:
                gameObject.transform.localPosition = new Vector3(0F, -220F, 0F);
                //gameObject.transform.position = new Vector3(0F, -220F, 0F);
                break;

            case Settings.numpadPosition.POS_DOWN_RIGHT:
                gameObject.transform.localPosition = new Vector3(90F, -220F, 0F);
                //gameObject.transform.position = new Vector3(90F, -220F, 0F);
                break;
        }
    }

    public void hide()
    {
        gameObject.SetActive(false);
        selectedArea = null;
    }
}
