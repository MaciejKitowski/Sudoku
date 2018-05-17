using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardNumeric : MonoBehaviour {
    public void NumericButtonPressed(int value) {
        Debug.Log($"Pressed {value} button");
    }

    public void ClearButtonPressed() {
        Debug.Log("Pressed CLEAR button");
    }

    public void ReturnButtonPressed() {
        Debug.Log("Pressed RETURN button");
    }
}
