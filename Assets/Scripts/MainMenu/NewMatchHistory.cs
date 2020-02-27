using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class NewMatchHistory : MonoBehaviour {
    [SerializeField] private GameObject container = null;
    [SerializeField] private GameObject prefab = null;

    private string DirectoryPath = null;
    private float currentPosY = 0;

    private void Start() {
        currentPosY = -prefab.GetComponent<RectTransform>().rect.height * 9;
        SetContainer();
    }

    private void SetContainer() {
        Debug.Log("Display Match History submenu");
        gameObject.SetActive(true);

        RectTransform containerRect = container.GetComponent<RectTransform>();
        float prefabHeight = prefab.GetComponent<RectTransform>().rect.height;

        string directoryPath = Path.Combine(Application.persistentDataPath, "Match History");
        if(!Directory.Exists(directoryPath))
        {
            Debug.Log("Directory created: " + directoryPath);
            Directory.CreateDirectory(directoryPath);
        }

         var jsonFiles = Directory.EnumerateFiles(directoryPath, "*.json");

        int times = 10;

        foreach (string filepath in jsonFiles) 
        {
            times -= 1;    
        }

        for(int i = 0; i < times; i++) {
            GameObject obj = Instantiate(prefab, container.transform);
            var rct = obj.GetComponent<RectTransform>();
            rct.anchoredPosition = new Vector3(rct.position.x, currentPosY);
            obj.SetActive(false);

            currentPosY += prefabHeight;
        }

        foreach (string filepath in jsonFiles) {
            var rawJson = File.ReadAllText(filepath);
            var node = JSON.Parse(rawJson);

            containerRect.sizeDelta = new Vector2(containerRect.sizeDelta.x, containerRect.sizeDelta.y + prefabHeight);

            GameObject obj = Instantiate(prefab, container.transform);
            var rct = obj.GetComponent<RectTransform>();
            rct.anchoredPosition = new Vector3(rct.position.x, currentPosY);
            var item = obj.GetComponent<MatchHistoryEntry>();
            LevelMatchHistory matchHistory = new LevelMatchHistory(node); 
            item.SetMatch(matchHistory);

            currentPosY += prefabHeight;
        }
    }

}
