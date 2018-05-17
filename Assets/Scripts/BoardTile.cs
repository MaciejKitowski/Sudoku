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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) Value++;
	}
}
