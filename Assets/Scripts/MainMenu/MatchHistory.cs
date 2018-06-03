using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHistory : MonoBehaviour {
    [SerializeField] private SelectLevel selectLevel = null;
    [SerializeField] private GameObject container = null;
    [SerializeField] private GameObject prefab = null;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonBack();
    }

    public void Display(Level level) {
        Debug.Log("Display Match History submenu");
        gameObject.SetActive(true);

        RectTransform rect = container.GetComponent<RectTransform>();
        float prefabHeight = prefab.GetComponent<RectTransform>().rect.height;
        float currentPosY = 0;

        foreach(var his in level.History) {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + prefabHeight);

            GameObject obj = Instantiate(prefab, container.transform);
            var rct = obj.GetComponent<RectTransform>();
            Debug.Log(rct.anchoredPosition);
            rct.anchoredPosition = new Vector3(rct.position.x, currentPosY);
            var item = obj.GetComponent<MatchHistoryItem>();
            item.SetMatch(his);


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
}
