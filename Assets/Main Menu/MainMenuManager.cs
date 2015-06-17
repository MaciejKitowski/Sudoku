using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour 
{
    public ExitGameController exitPanel;
    public MainController mainMenu;
    public SelectModeController selectModePanel;
    public SelectLevelController selectLevelPanel;
	
	void Start () 
    {
        exitPanel = gameObject.transform.GetComponentInChildren<ExitGameController>();
        mainMenu = gameObject.transform.GetComponentInChildren<MainController>();
        selectModePanel = gameObject.transform.GetComponentInChildren<SelectModeController>();
        selectLevelPanel = gameObject.transform.GetComponentInChildren<SelectLevelController>();

        mainMenu.setActive(true);
        exitPanel.setActive(false);
        selectModePanel.setActive(false);
        selectLevelPanel.setActive(false);
	}
}
