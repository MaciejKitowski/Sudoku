using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTile : MonoBehaviour {
    public delegate void TilePressedDelegate(BoardTile sender);
    public static event TilePressedDelegate TilePressed;

    [SerializeField] private bool constant = false;
    [SerializeField] private Text valueField;

    private int value = 0;

    public int Value {
        get { return value; }
        set {
            this.value = value;

            if (value != 0) valueField.text = $"{value}";
            else valueField.text = "";
        }
    }

    public void SetConstantValue(int value) {
        if(value == 0) Debug.LogError("Constant value cannot be 0", gameObject);
        else {
            Value = value;
            constant = true;
        }
    }

    private void OnMouseDown() {
        if(!constant) {
            Debug.Log("Tile pressed", gameObject);

            if (TilePressed == null) Debug.LogWarning("TilePressed event is empty", gameObject);
            else TilePressed(this);
        }
    }
}
