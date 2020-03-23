using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class Saver : MonoBehaviour
{
	private Level savedLevel = null;
	private JSONObject node = null;
	private string filepath = null;
	private string directoryPath = null;

	public void SaveLevelData(BoardTile[,] tiles)
	{
		SaveTilesToNode(tiles);
		File.WriteAllText(filepath, node.ToString());
		Debug.Log("Level saved");
	}

	public void SaveLevel()
	{
		savedLevel = LevelManager.Instance.SelectedLevel;
		string directoryPath = Path.Combine(Application.persistentDataPath, "Playing Levels");
		if(!Directory.Exists(directoryPath))
		{
			Debug.Log("Directory created: " + directoryPath);
			Directory.CreateDirectory(directoryPath);
		}

		var hashcode = savedLevel.GetHashCode();
		node = new JSONObject();
		filepath = Path.Combine(directoryPath, hashcode.ToString() + ".json");
		node["hashcode"] = hashcode;
		ParseMatchHistory();
	}

	private void SaveTilesToNode(BoardTile[,] tiles)
	{
		for(int y = 0; y < 9; ++y)
		{
			for(int x = 0; x < 9; ++x)
			{
				node["board"][y][x].AsInt = tiles[x, y].Value;					
				node["display"][y][x].AsInt = tiles[x, y].Constant ? 1 : 0;
			}
		}
	}

	public void CleanSaveFile()
	{
		if(File.Exists(filepath))
		{
			File.Delete(filepath);
			PlayerPrefs.DeleteKey("SavedLevelHashcode");
		}
	}

	private void ParseMatchHistory() {
        directoryPath = Path.Combine(Application.persistentDataPath, "Match History");
        if(!Directory.Exists(directoryPath))
        {
            Debug.Log("Directory created: " + directoryPath);
            Directory.CreateDirectory(directoryPath);
        }
        var jsonFiles = Directory.EnumerateFiles(directoryPath, "*.json");

        foreach (string filepath in jsonFiles) 
        {
            var rawJson = File.ReadAllText(filepath);
            var node = JSON.Parse(rawJson);
        }           
    }

    public void AddMatch(Level level) {
        if(level.History.Count > 0) {
            LevelMatchHistory matchHistory = level.History[0];
            for(int i = 0; i < 10; i++) {
                string filepath = Path.Combine(directoryPath, "Json" + i + ".json");
                if(!File.Exists(filepath)){
                    File.WriteAllText(filepath, matchHistory.Serialize().ToString());
                    break;
                }
                else if(i == 9) {
                	for(int j = 1; j < 10; j++) {
                		filepath = Path.Combine(directoryPath, "Json" + i + ".json");
                		string text = File.ReadAllText(filepath);
                		filepath = Path.Combine(directoryPath, "Json" + (i-1) + ".json");
                		File.WriteAllText(filepath, text);
                	}
                	filepath = Path.Combine(directoryPath, "Json" + 9 + ".json");
                	File.WriteAllText(filepath, matchHistory.Serialize().ToString());
                }
            }
        } 
        else 
            Debug.LogError("Level doesn't have match history");
    }
}
