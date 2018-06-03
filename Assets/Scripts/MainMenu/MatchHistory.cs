using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHistory : MonoBehaviour {
    [SerializeField] private SelectLevel selectLevel = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Display(Level level) {
        Debug.Log("Display Match History submenu");
    }

    public void Hide() {
        Debug.Log("Hide Match History submenu");
    }

    public void ButtonBackToMenu() {
        Debug.Log("Pressed Backu button");
        selectLevel.Display();
        this.Hide();
    }
}
