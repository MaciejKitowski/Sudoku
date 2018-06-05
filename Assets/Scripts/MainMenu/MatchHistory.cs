using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHistory : MonoBehaviour {
    [SerializeField] private SelectLevel selectLevel = null;
    [SerializeField] private GameObject container = null;
    [SerializeField] private GameObject prefab = null;

    private List<GameObject> matchEntries = new List<GameObject>();

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonBack();
    }

    public void Display(Level level) {
        Debug.Log("Display Match History submenu");
        gameObject.SetActive(true);
        if (matchEntries.Count > 0) ClearList();

        RectTransform containerRect = container.GetComponent<RectTransform>();
        float prefabHeight = prefab.GetComponent<RectTransform>().rect.height;
        float currentPosY = 0;

        foreach(var his in level.History) {
            containerRect.sizeDelta = new Vector2(containerRect.sizeDelta.x, containerRect.sizeDelta.y + prefabHeight);

            GameObject obj = Instantiate(prefab, container.transform);
            var rct = obj.GetComponent<RectTransform>();
            rct.anchoredPosition = new Vector3(rct.position.x, currentPosY);
            var item = obj.GetComponent<MatchHistoryEntry>();
            item.SetMatch(his);
            matchEntries.Add(obj);

            currentPosY -= prefabHeight;
        }
    }

    public void Hide() {
        Debug.Log("Hide Match History submenu");
        gameObject.SetActive(false);
    }

    public void ButtonBack() {
        Debug.Log("Pressed Backu button");
        selectLevel.Display();
        this.Hide();
    }

    private void ClearList() {
        Debug.Log("Clear match list");

        foreach (var obj in matchEntries) Destroy(obj);
    }
}
