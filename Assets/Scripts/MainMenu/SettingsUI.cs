using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject soundButton;
    [SerializeField] private Text soundText;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private bool soundOn = false;


    void Start()
    {
        PlayerPrefs.GetInt("sound", 0);
    	if(PlayerPrefs.HasKey("sound")){
    		soundOn = PlayerPrefs.GetInt("sound") != 0;
    		soundOn = !soundOn;
    	}
    	SoundButton();
    }

    public void SoundButton (){
    	soundOn = !soundOn;
    	if(soundOn){
    		soundButton.GetComponent<Image>().sprite = soundOnSprite;
    		soundText.text = "Sound On";
    		PlayerPrefs.SetInt("sound", 1);
    	}
    	else {
    		soundButton.GetComponent<Image>().sprite = soundOffSprite;
    		soundText.text = "Sound Off";
    		PlayerPrefs.SetInt("sound", 0);
    	}
    }
}
