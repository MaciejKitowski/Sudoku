using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class checkButtonController : MonoBehaviour 
{
    public bool active;

    void OnMouseDown()
    {
        if(active)
        {
            Debug.Log("Check button: Check sudoku");
            gameManager.checkSudoku();
        }
    }
	
    public void activate()
    {
        active = true;
        gameObject.GetComponent<RawImage>().color = Color.white;
    }

    public void deactivate()
    {
        active = false;
        gameObject.GetComponent<RawImage>().color = new Color32(150, 150, 150, 255);
    }
}
