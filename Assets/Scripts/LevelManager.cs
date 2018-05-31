using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class LevelManager : MonoBehaviour {
    public enum Difficult { EASY, MEDIUM, HARD }

    public Level SelectedLevel { get; private set; } = null;

    private Dictionary<Difficult, List<Level>> levels = new Dictionary<Difficult, List<Level>>();
    private string path = null;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        path = Path.Combine(Application.persistentDataPath, "Levels");
        DeserializeLevels();
    }

    private void OnDestroy() {
        Debug.LogWarning("Delete Levels directory from persistentDataPath");
        Directory.Delete(path, true);
    }

    private void DeserializeLevels() {
        if(Directory.Exists(path)) {
            Debug.Log("Start deserializing levels");

            levels[Difficult.EASY] = DeserializeDifficult("Easy");
            levels[Difficult.MEDIUM] = DeserializeDifficult("Medium");
            levels[Difficult.HARD] = DeserializeDifficult("Hard");

            string debugMessage = "Deserialization finished, found levels:";
            foreach (var diff in levels.Keys) debugMessage += $"\n\t{diff}: {levels[diff].Count}";
            Debug.Log(debugMessage);
        }
        else {
            Debug.Log("Levels directory not exists");
            CopyLevelsFromResources();
            DeserializeLevels();
        }
    }

    private List<Level> DeserializeDifficult(string directory) {
        var list = new List<Level>();
        var dirpath = Path.Combine(path, directory);
        var files = Directory.EnumerateFiles(dirpath, "*.json");
        Debug.Log($"Deserialize levels from {dirpath}");

        foreach(string filepath in files) {
            Debug.Log($"Load level from: {filepath}");

            var rawJson = File.ReadAllText(filepath);
            var node = JSON.Parse(rawJson);

            list.Add(new Level(node));
        }

        return list;
    }

    private void CopyLevelsFromResources() {
        Debug.Log("Copy levels from resources");

        Directory.CreateDirectory(path);
        CopyDifficultFromResources("Easy");
        CopyDifficultFromResources("Medium");
        CopyDifficultFromResources("Hard");
    }

    private void CopyDifficultFromResources(string name) {
        string levelPath = Path.Combine(path, name);
        Debug.Log($"Copy {name} difficult to: {levelPath}");
        Directory.CreateDirectory(levelPath);

        TextAsset[] files = Resources.LoadAll<TextAsset>($"Levels/{name}");
        Debug.Log($"Found files: {files.Length}");

        foreach(var file in files) {
            string filepath = Path.Combine(levelPath, file.name + ".json");
            Debug.Log($"Save {file.name}.json to {filepath}");

            File.WriteAllText(filepath, file.text);
        }
    }
}
