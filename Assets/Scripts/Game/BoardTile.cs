using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTile : MonoBehaviour {
    private static readonly Color constantBackground = Color.gray;

    public delegate void TilePressedDelegate(BoardTile sender);
    public delegate void ValueChangedDelegate();

    public event TilePressedDelegate TilePressed;
    public event ValueChangedDelegate ValueChanged;

    [SerializeField] private Text valueField;

    private bool constant = false;
    private int value = 0;

    public int Value {
        get { return value; }
        set {
            this.value = value;

            if (value != 0) {
                valueField.text = $"{value}";

                if (ValueChanged != null) ValueChanged();
            }
            else valueField.text = "";
        }
    }

    public void SetConstantValue(int value) {
        if(value == 0) Debug.LogError("Constant value cannot be 0", gameObject);
        else {
            Value = value;
            constant = true;
            GetComponent<Image>().color = constantBackground;
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
