using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [SerializeField] private Board board = null;
    [SerializeField] private Text timerText = null;
    [SerializeField] private Text moveCounterText = null;
    [SerializeField] private GameFinish gameFinish = null;

    private LevelManager levelManager = null;
    private int elapsedSeconds = 0;
    private int moves = 0;

    public bool Playing { get; private set; } = false;

    public int Moves {
        get { return moves; }
        set {
            moves = value;
            moveCounterText.text = $"{value:D3}";
        }
    }

    private int ElapsedSeconds {
        get { return elapsedSeconds; }
        set {
            elapsedSeconds = value;
            timerText.text = $"{value / 60:D2}:{value % 60:D2}";
        }
    }

	void Awake() {
        levelManager = LevelManager.Instance;
        board.BoardFinishedLoading += BoardFinishedLoading;
        board.BoardReadyToPlay += BoardReadyToPlay;
        board.SudokuCorrect += SudokuCorrect;

        ElapsedSeconds = 0;
        Moves = 0;
	}

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) CancelLevel();
    }

    private void OnDestroy() {
        Playing = false;
    }

    private void BoardFinishedLoading() {
        Debug.Log("Board finished loading, set level");
        SetLevelOnBoard();
    }

    private void BoardReadyToPlay() {
        Debug.Log("Board is ready to play");
        Playing = true;
        ElapsedSeconds = 0;
        Moves = 0;

        StartTimer();
    }

    private void SetLevelOnBoard() {
        if (levelManager.SelectedLevel == null) Debug.LogError("Selected level is null");
        else {
            Debug.Log("Set level on board");
            board.SetLevel(levelManager.SelectedLevel);
        }
    }

    private void SudokuCorrect() {
        Debug.Log("Sudoku correct!");
        Playing = false;

        gameFinish.Display(true, elapsedSeconds, moves);
    }

    private void CancelLevel() {
        if(!gameFinish.isActiveAndEnabled) {
            Debug.Log("Cancel game!");
            Playing = false;

            gameFinish.Display(false, elapsedSeconds, moves);
        }
    }

    private async void StartTimer() {
        while(Playing) {
            await Task.Delay(1000);
            ElapsedSeconds++;
        }
    }
}
