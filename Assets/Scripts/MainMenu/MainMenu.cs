using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void ButtonSelectLevel() {
        Debug.Log("Pressed Select Level button");
    }

    public void ButtonExitGame() {
        Debug.Log("Pressed Exit Game button");
        Application.Quit();
    }
}
