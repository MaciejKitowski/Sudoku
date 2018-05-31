using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    [SerializeField] private MainMenu mainMenu = null;
    [SerializeField] private Dropdown difficultDropdown = null;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonBackToMenu();
    }

    public void Display() {
        Debug.Log("Display Select Level submenu");
        gameObject.SetActive(true);
    }

    public void Hide() {
        Debug.Log("Hide Select Level submenu");
        gameObject.SetActive(false);
    }

    public void ButtonNewGame() {
        Debug.Log("Pressed New Game button");
    }

    public void ButtonMatchHistory() {
        Debug.Log("Pressed Match History button");
    }

    public void ButtonBackToMenu() {
        Debug.Log("Pressed Back To Main Menu button");
        mainMenu.Display();
        this.Hide();
    }

    public void DropdownChangeDifficult() {
        Debug.Log($"Changed difficult to {difficultDropdown.options[difficultDropdown.value].text}");
    }
}
