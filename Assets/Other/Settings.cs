using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour 
{
    public enum numpadPosition { POS_LEFT, POS_CENTER, POS_RIGHT, POS_DOWN_LEFT, POS_DOWN_CENTER, POS_DOWN_RIGHT }
    public static numpadPosition numpadPos;
    public static bool invertedNumpad;
    public static bool soundMute;

	void Awake () 
    {
    #if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
    #endif

        if (PlayerPrefs.HasKey("CheckPlayerPrefs")) loadFromPlayerPrefs();
        else
        {
            invertedNumpad = false;
            soundMute = false;
            numpadPos = numpadPosition.POS_CENTER;
            saveToPlayerPrefs();
        }
	}

    private static void loadFromPlayerPrefs()
    {
        if (PlayerPrefs.GetInt("invertedNum") == 1) invertedNumpad = true;
        else invertedNumpad = false;

        if (PlayerPrefs.GetInt("soundMute") == 1) soundMute = true;
        else soundMute = false;

        switch (PlayerPrefs.GetInt("NumpadPos"))
        {
            case 1:
                numpadPos = numpadPosition.POS_LEFT;
                break;
            case 2:
                numpadPos = numpadPosition.POS_CENTER;
                break;
            case 3:
                numpadPos = numpadPosition.POS_RIGHT;
                break;
            case 4:
                numpadPos = numpadPosition.POS_DOWN_LEFT;
                break;
            case 5:
                numpadPos = numpadPosition.POS_DOWN_CENTER;
                break;
            case 6:
                numpadPos = numpadPosition.POS_DOWN_RIGHT;
                break;
        }
    }
	
    public static void saveToPlayerPrefs()
    {
        PlayerPrefs.SetInt("CheckPlayerPrefs", 1);
        if (invertedNumpad) PlayerPrefs.SetInt("invertedNum", 1);
        else PlayerPrefs.SetInt("invertedNum", 0);

        if (soundMute) PlayerPrefs.SetInt("soundMute", 1);
        else PlayerPrefs.SetInt("soundMute", 0);

        switch (numpadPos)
        {
            case numpadPosition.POS_LEFT:
                PlayerPrefs.SetInt("NumpadPos", 1);
                break;
            case numpadPosition.POS_CENTER:
                PlayerPrefs.SetInt("NumpadPos", 2);
                break;
            case numpadPosition.POS_RIGHT:
                PlayerPrefs.SetInt("NumpadPos", 3);
                break;
            case numpadPosition.POS_DOWN_LEFT:
                PlayerPrefs.SetInt("NumpadPos", 4);
                break;
            case numpadPosition.POS_DOWN_CENTER:
                PlayerPrefs.SetInt("NumpadPos", 5);
                break;
            case numpadPosition.POS_DOWN_RIGHT:
                PlayerPrefs.SetInt("NumpadPos", 6);
                break;
        }
    }
}
