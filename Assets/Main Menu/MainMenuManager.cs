using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour 
{
    public ExitGameController exitPanel;
    public MainController mainMenu;
	
	void Start () 
    {
        exitPanel = gameObject.transform.GetComponentInChildren<ExitGameController>();
        mainMenu = gameObject.transform.GetComponentInChildren<MainController>();

        exitPanel.setActive(false);
        mainMenu.setActive(true);
	}
}
