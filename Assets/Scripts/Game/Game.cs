using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] private Board board = null;

    private LevelManager levelManager = null;

	void Awake() {
        levelManager = LevelManager.Instance;
        board.BoardFinishedLoading += BoardFinishedLoading;
        board.BoardReadyToPlay += BoardReadyToPlay;
	}

    private void BoardFinishedLoading() {
        Debug.Log("Board finished loading, set level");

        if (levelManager.SelectedLevel == null) Debug.LogError("Selected level is null");
        else {
            Debug.Log("Set level on board");
            board.SetLevel(levelManager.SelectedLevel);
        }
    }

    private void BoardReadyToPlay() {
        Debug.Log("Board is ready to play");
    }
}
