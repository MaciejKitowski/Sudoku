using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class KeyboardNumeric : MonoBehaviour {
    private BoardTile activeTile = null;

    bool readyToPress = false;

    private void Start() {
        BoardTile.TilePressed += Display;

        Hide();
    }

    //D E B U G
    private void Update() {
        if(gameObject.activeInHierarchy) {
            if (Input.GetKeyDown(KeyCode.Keypad0)) ClearButtonPressed();
            if (Input.GetKeyDown(KeyCode.Keypad1)) NumericButtonPressed(1);
            if (Input.GetKeyDown(KeyCode.Keypad2)) NumericButtonPressed(2);
            if (Input.GetKeyDown(KeyCode.Keypad3)) NumericButtonPressed(3);
            if (Input.GetKeyDown(KeyCode.Keypad4)) NumericButtonPressed(4);
            if (Input.GetKeyDown(KeyCode.Keypad5)) NumericButtonPressed(5);
            if (Input.GetKeyDown(KeyCode.Keypad6)) NumericButtonPressed(6);
            if (Input.GetKeyDown(KeyCode.Keypad7)) NumericButtonPressed(7);
            if (Input.GetKeyDown(KeyCode.Keypad8)) NumericButtonPressed(8);
            if (Input.GetKeyDown(KeyCode.Keypad9)) NumericButtonPressed(9);
        }
    }

    public void Display(BoardTile pressedTile) {
        if (!gameObject.activeInHierarchy) {
            Debug.Log("Display keyboard with tile", pressedTile);
            gameObject.SetActive(true);
            activeTile = pressedTile;

            readyToPress = false;
            WaitToReleaseButton();
        }
    }

    public void Hide() {
        Debug.Log("Hide keyboard");
        gameObject.SetActive(false);
    }

    public void NumericButtonPressed(int value) {
        if (readyToPress) {
            Debug.Log($"Pressed {value} button");
            activeTile.Value = value;
            Hide();
        }
    }

    public void ClearButtonPressed() {
        if (readyToPress) {
            Debug.Log("Pressed CLEAR button");
            activeTile.Value = 0;
            Hide();
        }
    }

    public void ReturnButtonPressed() {
        if (readyToPress) {
            Debug.Log("Pressed RETURN button");
            Hide();
        }
    }

    //Delay for mouse and touch input, prevent from accidentally select board tile and keyboard number button at once
    private async void WaitToReleaseButton() {
        while (Input.anyKey || Input.touchCount != 0) {
            await Task.Delay(100);
        }

        Debug.Log("Button/touch released");
        await Task.Delay(50);
        readyToPress = true;
    }
}
