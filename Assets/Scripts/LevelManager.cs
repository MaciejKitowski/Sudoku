using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using SimpleJSON;
using System.Threading.Tasks;

public class LevelManager {
    private static LevelManager instance = null;

    private readonly string path = null;

    public enum Difficult { EASY, MEDIUM, HARD }
    private Dictionary<Difficult, List<Level>> levels = new Dictionary<Difficult, List<Level>>();
    
    public static LevelManager Instance {
        get {
            if (instance == null) instance = new LevelManager();
            return instance;
        }
    }

    public Difficult SelectedDifficult { get; set; } = Difficult.EASY;
    public Level SelectedLevel { get; private set; } = null;
    public List<Level> DifficultLevels { get { return levels[SelectedDifficult]; } }

    private LevelManager() {
        path = Path.Combine(Application.persistentDataPath, "Levels");

        Debug.LogWarning("Delete Levels directory from persistentDataPath");
        Debug.Log(path);
        Debug.Log(Directory.Exists(path));
        Directory.Delete(path, true);

        
        Debug.Log(Directory.Exists(path));

        DeserializeLevels();

        Debug.Log(Directory.Exists(path));
    }

    public void StartLevel(int index) {
        Debug.Log($"Start {SelectedDifficult} level: {index}");
        SelectedLevel = DifficultLevels[index];
        LoadGameScene();
    }

    private async void LoadGameScene() {
        Debug.Log("Load game scene");

        var asyncLoad = SceneManager.LoadSceneAsync("Game");
        while (!asyncLoad.isDone) await Task.Delay(15);
    }

    private void DeserializeLevels() {
        Debug.Log("AAAA");

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
