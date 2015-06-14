using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour 
{
    public ExitGameController exitPanel;
    public MainController mainMenu;
    public SelectModeController selectModePanel;
	
	void Start () 
    {
        exitPanel = gameObject.transform.GetComponentInChildren<ExitGameController>();
        mainMenu = gameObject.transform.GetComponentInChildren<MainController>();
        selectModePanel = gameObject.transform.GetComponentInChildren<SelectModeController>();

        mainMenu.setActive(true);
        exitPanel.setActive(false);
        selectModePanel.setActive(false);
	}
}
