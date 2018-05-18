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
