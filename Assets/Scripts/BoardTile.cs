using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTile : MonoBehaviour {
    public delegate void TilePressedDelegate(BoardTile sender);
    public event TilePressedDelegate TilePressed;

    private static readonly Color constantBackground = Color.gray;

    [SerializeField] private Text valueField;

    private bool constant = false;
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
            GetComponent<SpriteRenderer>().color = constantBackground;
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
