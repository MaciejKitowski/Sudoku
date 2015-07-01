using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsController : MonoBehaviour 
{
    public bool active;

    private Toggle soundMute;
	
	void Awake () 
    {
        soundMute = gameObject.transform.GetChild(2).GetComponent<Toggle>();
        soundMute.isOn = Settings.soundMute;
	}
	
	public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);
    }

    public void buttonBackToMenu()
    {
        Debug.Log("Back to menu button");
        gameManager.audio.play();
        setActive(false);
    }

    public void toggleSounds()
    {
        Debug.Log("Toggle sounds mute");
        gameManager.audio.play();
        Settings.soundMute = soundMute.isOn;
    }
}
