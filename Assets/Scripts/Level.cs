using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using System.Globalization;

public class Level {
    private int[,] board = new int[9, 9];
    private bool[,] display = new bool[9, 9];
    private long hashcode = 0;
    private List<LevelMatchHistory> history = new List<LevelMatchHistory>();
    
    public int[,] Board { get { return board; } }
    public bool[,] Display { get { return display; } }

    public Level(JSONNode node) {
        Debug.Log($"Deserialize level from json: {node.ToString()}");
        DeserializeBoard(node);
        DeserializeDisplay(node);
        hashcode = node["hashcode"].AsLong;
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
    private int moves = 0;
    private DateTime startDate = new DateTime();
    private int elapsedSeconds = 0;

    public LevelMatchHistory(JSONNode node) {
        Debug.Log($"Deserialize level match history from json: {node.ToString()}");

        won = node["won"].AsBool;
        moves = node["moves"].AsInt;
        startDate = DateTime.ParseExact(node["date"], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        elapsedSeconds = node["elapsedSeconds"];
    }
}
