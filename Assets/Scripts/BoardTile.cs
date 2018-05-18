using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTile : MonoBehaviour {
    public delegate void TilePressedDelegate(BoardTile sender);
    public static event TilePressedDelegate TilePressed;

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

    private void OnMouseDown() {
        Debug.Log("Tile pressed", gameObject);

        if (TilePressed == null) Debug.LogWarning("TilePressed event is empty", gameObject);
        else TilePressed(this);
    }
}
