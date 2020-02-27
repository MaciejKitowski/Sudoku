using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
	[SerializeField] private Saver saver;
	[SerializeField] private Game game;

    [SerializeField] private GameObject soundButton;
    [SerializeField] private Text soundText;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    [SerializeField] private GameObject pauseScreen;

    private bool soundOn = false;
    private bool paused = false;

    void Start()
    {
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

    public void PauseButton()
    {
    	paused = !paused;
    	if(paused) {    		
    		pauseScreen.SetActive(true);
    		game.Playing = false;
    	}
    	else {
    		pauseScreen.SetActive(false);    		
    		game.Playing = true;
    	}
    }

    public void ButtonPlayAgain() {
        Debug.Log("Pressed Play Again button");
        HidePauseScreen();
    }

    public void ButtonCancelLevel() {
        Debug.Log("Pressed Back To Menu button");
        saver.CleanSaveFile();
        game.CancelLevel();
    }

    private void HidePauseScreen() {
        PauseButton();
    }

    private async void LoadMainMenuScene() {
        Debug.Log("Load Main Menu scene");

        var asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        while (!asyncLoad.isDone) await Task.Delay(15);
    }
}
