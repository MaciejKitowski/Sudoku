using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour {
    private List<Level> easy = new List<Level>();
    private List<Level> medium = new List<Level>();
    private List<Level> hard = new List<Level>();

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

            DeserializeDifficult("Easy", easy);
            DeserializeDifficult("Medium", medium);
            DeserializeDifficult("Hard", hard);

            Debug.Log($"Deserialized levels finished, found levels: Easy:{easy.Count}, Medium:{medium.Count}, Hard:{hard.Count}");
        }
        else {
            Debug.Log("Levels directory not exists");
            CopyLevelsFromResources();
            DeserializeLevels();
        }
    }

    private void DeserializeDifficult(string name, List<Level> list) {
        string levelPath = Path.Combine(path, name);
        var files = Directory.EnumerateFiles(levelPath, "*.json");
        Debug.Log($"Deserialize {name} difficult from: {levelPath}");

        foreach (string file in files) {
            Debug.Log($"Load level from file: {file}");
        }
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
