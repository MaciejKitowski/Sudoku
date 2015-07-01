using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsController : MonoBehaviour 
{
    public bool active;

    private Toggle soundMute;
    private Toggle invertNumpad;

    private Toggle[] numpadPosition;
    private ToggleGroup numpadPosGroup;
	
	void Awake () 
    {
        numpadPosition = new Toggle[6];

        soundMute = gameObject.transform.GetChild(2).gameObject.GetComponent<Toggle>();
        invertNumpad = gameObject.transform.GetChild(3).gameObject.GetComponent<Toggle>();
        numpadPosGroup = gameObject.transform.GetChild(4).gameObject.GetComponent<ToggleGroup>();

        for (int i = 4; i < 10; ++i)
        {
            numpadPosition[i - 4] = gameObject.transform.GetChild(i).gameObject.GetComponent<Toggle>();
            numpadPosition[i - 4].group = numpadPosGroup;
            numpadPosition[i - 4].isOn = false;
        }
	}

    public void load()
    {
        soundMute.isOn = Settings.soundMute;
        invertNumpad.isOn = Settings.invertedNumpad;

        switch (Settings.numpadPos)
        {
            case Settings.numpadPosition.POS_LEFT:
                numpadPosition[0].isOn = true;
                break;
            case Settings.numpadPosition.POS_CENTER:
                numpadPosition[1].isOn = true;
                break;
            case Settings.numpadPosition.POS_RIGHT:
                numpadPosition[2].isOn = true;
                break;
            case Settings.numpadPosition.POS_DOWN_LEFT:
                numpadPosition[3].isOn = true;
                break;
            case Settings.numpadPosition.POS_DOWN_CENTER:
                numpadPosition[4].isOn = true;
                break;
            case Settings.numpadPosition.POS_DOWN_RIGHT:
                numpadPosition[5].isOn = true;
                break;
        }
    }
	
	public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);
    }

    public void buttonBackToMenu()
    {
        Debug.Log("Back to menu button");
        //gameManager.audio.play();
        Settings.saveToPlayerPrefs();
        setActive(false);
    }

    public void toggleSounds()
    {
        Debug.Log("Toggle sounds mute");
        //gameManager.audio.play();
        Settings.soundMute = soundMute.isOn;
    }

    public void toggleInvertNumpad()
    {
        Debug.Log("Toggle invert numpad");
        //gameManager.audio.play();
        Settings.invertedNumpad = invertNumpad.isOn;
    }

    public void toggleNumpadPosition()
    {
        Debug.Log("Toggle numpad position");

        if (numpadPosition[0].isOn) Settings.numpadPos = Settings.numpadPosition.POS_LEFT;
        else if (numpadPosition[1].isOn) Settings.numpadPos = Settings.numpadPosition.POS_CENTER;
        else if (numpadPosition[2].isOn) Settings.numpadPos = Settings.numpadPosition.POS_RIGHT;
        else if (numpadPosition[3].isOn) Settings.numpadPos = Settings.numpadPosition.POS_DOWN_LEFT;
        else if (numpadPosition[4].isOn) Settings.numpadPos = Settings.numpadPosition.POS_DOWN_CENTER;
        else if (numpadPosition[5].isOn) Settings.numpadPos = Settings.numpadPosition.POS_DOWN_RIGHT;
    }
}
