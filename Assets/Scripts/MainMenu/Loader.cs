using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class Loader : MonoBehaviour
{
	//[SerializeField] private LevelManager levelManager;

	public void LoadSavedLevel()
	{
		string DirectoryPath = Path.Combine(Application.persistentDataPath, "Playing Levels");
		if(Directory.Exists(DirectoryPath))
		{
			var jsonFiles = Directory.EnumerateFiles(DirectoryPath, "*.json");
	
			foreach (string filepath in jsonFiles) 
			{
				Debug.Log("toLoad file found: " + filepath);
				var rawJson = File.ReadAllText(filepath);
          		var node = JSON.Parse(rawJson);
				Level level = new Level(filepath, node, toLoad: true);
				LevelManager.Instance.StartLevel(level);
				break;
			}			
		}
		else Debug.LogError("Directory with file toLoad not found");
	}
}
