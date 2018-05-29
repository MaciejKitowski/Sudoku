using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelManager : MonoBehaviour {
    private List<Level> easy = new List<Level>();
    private List<Level> medium = new List<Level>();
    private List<Level> hard = new List<Level>();

    private string path = null;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        path = Path.Combine(Application.streamingAssetsPath, "Levels");
        DeserializeLevels();
    }

    private void DeserializeLevels() {
        Debug.Log("Start deserializing levels");

        DeserializeDifficult("Easy", easy);
        DeserializeDifficult("Medium", medium);
        DeserializeDifficult("Hard", hard);

        Debug.Log($"Deserialized levels finished, found levels: Easy:{easy.Count}, Medium:{medium.Count}, Hard:{hard.Count}");
    }

    private void DeserializeDifficult(string name, List<Level> list) {
        string levelPath = Path.Combine(path, name);
        Debug.Log($"Deserialize {name} difficult from: {levelPath}");

        var files = Directory.EnumerateFiles(levelPath, "*.json");
        
        foreach(string file in files) {
            Debug.Log($"Load level from file: {file}");
        }
    }
}
