using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

public class Level {
    private int[,] board = new int[9, 9];
    private bool[,] display = new bool[9, 9];
    private List<LevelMatchHistory> history = new List<LevelMatchHistory>();

    public int[,] Board { get { return board; } }
    public bool[,] Display { get { return display; } }

    public Level(JSONNode node) {
        Debug.Log($"Deserialize level from json: {node.ToString()}");
        DeserializeBoard(node);
        DeserializeDisplay(node);
        DeserializeHistory(node);

        Debug.Log("Deserialization finished");
    }

    private void DeserializeBoard(JSONNode node) {
        for (int y = 0; y < 9; ++y) {
            for (int x = 0; x < 9; ++x) {
                board[x, y] = node["board"][y][x].AsInt;
            }
        }
    }

    private void DeserializeDisplay(JSONNode node) {
        for (int y = 0; y < 9; ++y) {
            for (int x = 0; x < 9; ++x) {
                display[x, y] = (node["display"][y][x].AsInt == 1);
            }
        }
    }

    private void DeserializeHistory(JSONNode node) {
        var matches = node["MatchHistory"];

        for (int i = 0; i < matches.Count; ++i) {
            history.Add(new LevelMatchHistory(matches[i]));
        }

        Debug.Log($"Deserialized {history.Count} matches");
    }
}

public class LevelMatchHistory {
    private bool won = false;
    private bool finished = true;
    private int moves = 0;
    private DateTime startDate = new DateTime();
    private int elapsedSeconds = 0;

    public LevelMatchHistory(JSONNode node) {
        Debug.Log($"Deserialize level match history from json: {node.ToString()}");

        won = node["won"];
        finished = node["finished"];
        moves = node["moves"];
        elapsedSeconds = node["elapsedSeconds"];

        DeserializeStartDate(node);
    }

    private void DeserializeStartDate(JSONNode node) {
        string raw = node["date"];
        var splitted = raw.Split(' ', '-', ':');

        int year, month, day, hour, minutes;
        if (!int.TryParse(splitted[0], out year)) Debug.LogWarning($"Failed to parse year: {splitted[0]}");
        if (!int.TryParse(splitted[1], out month)) Debug.LogWarning($"Failed to parse month: {splitted[1]}");
        if (!int.TryParse(splitted[2], out day)) Debug.LogWarning($"Failed to parse day: {splitted[2]}");
        if (!int.TryParse(splitted[3], out hour)) Debug.LogWarning($"Failed to parse hour: {splitted[3]}");
        if (!int.TryParse(splitted[4], out minutes)) Debug.LogWarning($"Failed to parse minutes: {splitted[4]}");

        startDate = new DateTime(year, month, day, hour, minutes, 0);
        Debug.Log($"Parsed date: {startDate.ToString()}");
    }
}
