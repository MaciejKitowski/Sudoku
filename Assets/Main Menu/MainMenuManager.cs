using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour 
{
    public static ExitGameController exitPanel;
    public static MainController mainMenu;
    public static SelectModeController selectModePanel;
    public static SelectLevelController selectLevelPanel;
    public static DebugAddingLevelsController addLevels;
	
	void Start () 
    {
        exitPanel = gameObject.transform.GetComponentInChildren<ExitGameController>();
        mainMenu = gameObject.transform.GetComponentInChildren<MainController>();
        selectModePanel = gameObject.transform.GetComponentInChildren<SelectModeController>();
        selectLevelPanel = gameObject.transform.GetComponentInChildren<SelectLevelController>();
        addLevels = gameObject.transform.GetComponentInChildren<DebugAddingLevelsController>();

        mainMenu.setActive(true);
        exitPanel.setActive(false);
        selectModePanel.setActive(false);
        selectLevelPanel.setActive(false);
        addLevels.setActive(false);
	}
}
