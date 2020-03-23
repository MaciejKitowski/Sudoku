using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelNew : MonoBehaviour {
    [SerializeField] private Board board = null;
    [SerializeField] private Dropdown difficultDropdown = null;
    [SerializeField] private Loader loader = null;
    [SerializeField] private GameObject[] buttons = null;

    private LevelManager levelManager = null;
    private int currentLevelID = 0;
    private int levelCount = 0;

    private int CurrentLevel {
        get { return currentLevelID; }
        set {
            if (value < 0) currentLevelID = levelCount - 1;
            else if (value >= levelCount) currentLevelID = 0;
            else currentLevelID = value;
        }
    }

    private void Awake() {
        levelManager = LevelManager.Instance;
        loader.LoadSavedLevel();
        board.BoardFinishedLoading += BoardFinishedLoading;
        Debug.Log(Application.persistentDataPath);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
       // if (Input.touchCount > 0) HandleSwipeInput();

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            --CurrentLevel;
            UpdateDisplayedLevel();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            ++CurrentLevel;
            UpdateDisplayedLevel();
        }
    }

    public void ButtonNewGame() {
        Debug.Log("Pressed New Game button {CurrentLevel} level load");
        levelManager.StartLevel(CurrentLevel);
    }

    public void DropdownChangeDifficult() {
        Debug.Log($"Changed difficult dropdown");

        if (difficultDropdown.value == 0) levelManager.SelectedDifficult = LevelManager.Difficult.EASY;
        else if (difficultDropdown.value == 1) levelManager.SelectedDifficult = LevelManager.Difficult.MEDIUM;
        else levelManager.SelectedDifficult = LevelManager.Difficult.HARD;

        CurrentLevel = 0;
        levelCount = levelManager.DifficultLevels.Count;
        UpdateDisplayedLevel();
        UpdateScrollButtons();
    }

    private void UpdateScrollButtons()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            if(i < levelCount) buttons[i].SetActive(true);
            else    buttons[i].SetActive(false);
        }
    }

    private void BoardFinishedLoading() {
        Debug.Log("Board finished loading, set first level");
        CurrentLevel = 0;
        levelCount = levelManager.DifficultLevels.Count;
        UpdateDisplayedLevel();
    }

    private void UpdateDisplayedLevel() {
        board.Clear();
        board.SetLevel(levelManager.DifficultLevels[CurrentLevel]);
    }

    public void NumericButtonPressed(int value) 
    {
        CurrentLevel = value;
        UpdateDisplayedLevel();
    }
}
