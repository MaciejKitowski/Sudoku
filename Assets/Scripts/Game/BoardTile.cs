using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTile : MonoBehaviour {
    public static readonly Color constantBackground = new Color32(100, 100, 100, 255);
    public static readonly Color pressedBackgroundColor = Color.cyan;
    public static readonly Color pressedColor = Color.blue;
    public static readonly Color defaultBackgroundColor = Color.white;
    public static readonly Color defaultColor = Color.black;
    public static readonly Color highlighterBackgroundColor = new Color32(70, 28, 12, 30);

    public delegate void TilePressedDelegate(BoardTile sender);
    public delegate void ValueChangedDelegate();

    public event TilePressedDelegate TilePressed;
    public event ValueChangedDelegate ValueChanged;

    [SerializeField] private Text valueField;

    private bool constant = false;
    private int value = 0;
    private Color tileColor = defaultColor;
    private Color tileBackgroundColor = defaultBackgroundColor;

    public int Value {
        get { return value; }
        set {
            this.value = value;

            if (value != 0) {
                valueField.text = $"{value}";
                if (ValueChanged != null && !constant) ValueChanged();
            }
            else valueField.text = "";
        }
    }

    public bool Constant { get {return constant; } }

    public Color TileColor 
    {
        get {return tileColor; }
        set {
            tileColor = value;
            GetComponentInChildren<Text>().color = tileColor;
        }

    }

    public Color TileBackgroundColor {
        get {return tileBackgroundColor; }
        set {
            tileBackgroundColor = value;
            GetComponent<Image>().color = tileBackgroundColor; 
        }
    }

    public void Clear() {
        Value = 0;
        constant = false;
        TileColor = defaultColor;
    }

    public void SetConstantValue(int value) {
        if(value == 0) Debug.LogError("Constant value cannot be 0", gameObject);
        else {
            constant = true;
            Value = value;
            TileColor = constantBackground;
        }
    }

    public void SetValue(int value)
    {
        if(value > 0 && value <= 9)
        {
            this.value = value;
            valueField.text = $"{value}";
        }
        else if(value == 0) 
            valueField.text = "";
        else Debug.LogError("Incorect value to set");
    }

    private void OnMouseDown() {
        Debug.Log("Tile pressed", gameObject);

        if (TilePressed == null) Debug.LogWarning("TilePressed event is empty", gameObject);
        else TilePressed(this);
    }
}
