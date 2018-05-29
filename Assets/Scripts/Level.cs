using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

public class Level {
    private int[,] board = new int[9, 9];
    private bool[,] display = new bool[9, 9];
    private List<LevelMatchHistory> history = new List<LevelMatchHistory>();

    public Level(JSONNode node) {
        Debug.Log($"Deserialize level from json: {node.ToString()}");
        LoadBoard(node);
        LoadDisplay(node);

        Debug.Log("Deserialization finished");
    }

    private void LoadBoard(JSONNode node) {
        for (int y = 0; y < 9; ++y) {
            for (int x = 0; x < 9; ++x) {
                board[x, y] = node["board"][y][x].AsInt;
            }
        }
    }

    private void LoadDisplay(JSONNode node) {
        for (int y = 0; y < 9; ++y) {
            for (int x = 0; x < 9; ++x) {
                display[x, y] = (node["display"][y][x].AsInt == 1);
            }
        }
    }
}

public class LevelMatchHistory {
    private bool wasWon = false;
    private bool finished = true;
    private int moves = 0;
    private DateTimeOffset startDate = new DateTimeOffset();
    private int elapsedSeconds = 0;
}
