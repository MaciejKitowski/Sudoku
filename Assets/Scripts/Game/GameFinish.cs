using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour {
    [SerializeField] private Text resultText = null;
    [SerializeField] private Text timeValueText = null;
    [SerializeField] private Text movesValueText = null;

    public void Display(bool won, int elapsedSeconds, int moves) {
        Debug.Log("Display Game Finish message");

        if (won) resultText.text = "Won!";
        else resultText.text = "Lose!";

        timeValueText.text = $"{elapsedSeconds / 60:D2}:{elapsedSeconds % 60:D2}";
        movesValueText.text = $"{moves:D3}";

        gameObject.SetActive(true);
    }

    public void Hide() {
        Debug.Log("Hide Game Finish message");
        gameObject.SetActive(false);
    }

    public void ButtonPlayAgain() {
        Debug.Log("Pressed Play Again button");
    }

    public void ButtonBackToMenu() {
        Debug.Log("Pressed Back To Menu button");
    }
}
