using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    [SerializeField] private MainMenu mainMenu = null;
    [SerializeField] private MatchHistory matchHistory = null;
    [SerializeField] private Dropdown difficultDropdown = null;
    [SerializeField] private Text currentLevelText = null;
    [SerializeField] private Board board = null;

    private LevelManager levelManager = null;
    private int currentLevelID = 0;
    private int levelCount = 0;
    private float minSwipeDistance = 0;
    Vector2 swipeStartPosition = Vector2.zero;

    private int CurrentLevel {
        get { return currentLevelID; }
        set {
            if (value < 0) currentLevelID = levelCount - 1;
            else if (value >= levelCount) currentLevelID = 0;
            else currentLevelID = value;
        }
    }

    private void Start() {
        levelManager = LevelManager.Instance;
        board.BoardFinishedLoading += BoardFinishedLoading;

        minSwipeDistance = Screen.width / 20f;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonBackToMenu();
        if (Input.touchCount > 0) HandleSwipeInput();

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            --CurrentLevel;
            UpdateDisplayedLevel();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            ++CurrentLevel;
            UpdateDisplayedLevel();
        }
    }

    public void Display() {
        Debug.Log("Display Select Level submenu");
        gameObject.SetActive(true);
    }

    public void Hide() {
        Debug.Log("Hide Select Level submenu");
        gameObject.SetActive(false);
    }

    public void ButtonNewGame() {
        Debug.Log("Pressed New Game button");
        levelManager.StartLevel(CurrentLevel);
    }

    public void ButtonMatchHistory() {
        Debug.Log("Pressed Match History button");
        matchHistory.Display(levelManager.DifficultLevels[CurrentLevel]);
        this.Hide();
    }

    public void ButtonBackToMenu() {
        Debug.Log("Pressed Back To Main Menu button");
        mainMenu.Display();
        this.Hide();
    }

    public void DropdownChangeDifficult() {
        Debug.Log($"Changed difficult dropdown");

        if (difficultDropdown.value == 0) levelManager.SelectedDifficult = LevelManager.Difficult.EASY;
        else if (difficultDropdown.value == 1) levelManager.SelectedDifficult = LevelManager.Difficult.MEDIUM;
        else levelManager.SelectedDifficult = LevelManager.Difficult.HARD;

        CurrentLevel = 0;
        levelCount = levelManager.DifficultLevels.Count;
        UpdateDisplayedLevel();
    }

    private void BoardFinishedLoading() {
        Debug.Log("Board finished loading, set first level");
        DropdownChangeDifficult();
    }

    private void HandleSwipeInput() {
        var touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began) swipeStartPosition = touch.position;
        else if (touch.phase == TouchPhase.Ended) {
            var difference = swipeStartPosition - touch.position;

            if (Mathf.Abs(difference.x) > minSwipeDistance) {
                if (difference.normalized.x > 0.5f) ++CurrentLevel;
                else if (difference.normalized.y < 0.5f) --CurrentLevel;

                UpdateDisplayedLevel();
            }
        }
    }

    private void UpdateDisplayedLevel() {
        currentLevelText.text = $"{CurrentLevel + 1}/{levelCount}";
        board.Clear();
        board.SetLevel(levelManager.DifficultLevels[CurrentLevel]);
    }
}
