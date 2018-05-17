using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTile : MonoBehaviour {
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
        Value++;
    }
}
