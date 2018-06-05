using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using System.Globalization;
using System.Linq;

public class Level {
    private int[,] board = new int[9, 9];
    private bool[,] display = new bool[9, 9];
    private int hashcode = 0;
    private List<LevelMatchHistory> history = new List<LevelMatchHistory>();
    private JSONNode node = null;
    private string filepath = null;
    
    public int[,] Board { get { return board; } }
    public bool[,] Display { get { return display; } }
    public List<LevelMatchHistory> History { get { return history; } }
    
    public Level(string filepath, JSONNode node) {
        Debug.Log($"Deserialize level from json: {node.ToString()}");
        this.node = node;
        this.filepath = filepath;

        DeserializeBoard();
        DeserializeDisplay();
        hashcode = node["hashcode"];
        DeserializeHistory(node);

        Debug.Log("Deserialization finished");
    }

    public void AddNewMatch(bool won, int moves, DateTime date, int elapsedSeconds) {
        LevelMatchHistory history = new LevelMatchHistory(won, moves, date, elapsedSeconds);
        History.Add(history);

        node["MatchHistory"].Add(history.Serialize());
    }

    public void SaveToFile() {
        Debug.Log($"Save level {hashcode} to {filepath}: {node.ToString()}");
    }

    public override int GetHashCode() { return hashcode; }

    private void DeserializeBoard() {
        for (int y = 0; y < 9; ++y) {
            for (int x = 0; x < 9; ++x) {
                board[x, y] = node["board"][y][x].AsInt;
            }
        }
    }

    private void DeserializeDisplay() {
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

        history = history.OrderByDescending(it => it.StartDate).ToList();

        Debug.Log($"Deserialized {history.Count} matches");
    }
}

public class LevelMatchHistory {
    public bool Won { get; private set; } = false;
    public int Moves { get; private set; } = 0;
    public DateTime StartDate { get; private set; } = new DateTime();
    public int ElapsedSeconds { get; private set; } = 0;

    public LevelMatchHistory(JSONNode node) {
        Debug.Log($"Deserialize level match history from json: {node.ToString()}");

        Won = node["won"].AsBool;
        Moves = node["moves"].AsInt;
        StartDate = DateTime.ParseExact(node["date"], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        ElapsedSeconds = node["elapsedSeconds"];
    }

    public LevelMatchHistory(bool won, int moves, DateTime date, int elapsedSeconds) {
        Debug.Log($"Create new match history: won={won} moves={moves} date={date.ToString("yyyy-MM-dd HH:mm")} elapsed time={elapsedSeconds}");

        Won = won;
        Moves = moves;
        StartDate = date;
        ElapsedSeconds = elapsedSeconds;
    }

    public JSONNode Serialize() {
        JSONObject node = new JSONObject();
        node["won"] = Won;
        node["moves"] = Moves;
        node["date"] = StartDate.ToString("yyyy-MM-dd HH:mm");
        node["elapsedSeconds"] = ElapsedSeconds;

        Debug.Log($"Serialized match: {node.ToString()}");
        return node;
    }
}
