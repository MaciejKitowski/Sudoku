using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHistory : MonoBehaviour {
    [SerializeField] private SelectLevel selectLevel = null;
    [SerializeField] private GameObject container = null;
    [SerializeField] private GameObject prefab = null;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonBack();
    }

    public void Display(Level level) {
        Debug.Log("Display Match History submenu");
        gameObject.SetActive(true);
    }

    public void Hide() {
        Debug.Log("Hide Match History submenu");
        gameObject.SetActive(false);
    }

    public void ButtonBack() {
        Debug.Log("Pressed Backu button");
        selectLevel.Display();
        this.Hide();
    }
}
