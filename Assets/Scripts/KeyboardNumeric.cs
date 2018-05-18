using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardNumeric : MonoBehaviour {
    private BoardTile activeTile = null;

    public void Display(BoardTile pressedTile) {
        Debug.Log("Display keyboard with selected tile", pressedTile);
        gameObject.SetActive(true);
        activeTile = pressedTile;
    }

    public void Hide() {
        Debug.Log("Hide keyboard");
        gameObject.SetActive(false);
    }

    public void NumericButtonPressed(int value) {
        Debug.Log($"Pressed {value} button");
        activeTile.Value = value;
        Hide();
    }

    public void ClearButtonPressed() {
        Debug.Log("Pressed CLEAR button");
        activeTile.Value = 0;
        Hide();
    }

    public void ReturnButtonPressed() {
        Debug.Log("Pressed RETURN button");
        Hide();
    }
}
