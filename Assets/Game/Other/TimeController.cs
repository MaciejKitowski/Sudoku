using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController : MonoBehaviour 
{
    private int minutes;
    private int seconds;
    private string formatedText;
    private Text text;
	
	void Start () 
    {
        text = gameObject.GetComponent<Text>();
	}
	
	void Update () 
    {
        minutes = Mathf.FloorToInt(gameManager.timer / 60F);
        seconds = Mathf.FloorToInt(gameManager.timer - minutes * 60);
        formatedText = string.Format("{0:00}:{1:00}", minutes, seconds);
        text.text = formatedText;
	}
}
