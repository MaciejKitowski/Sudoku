using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectLevelController : MonoBehaviour 
{
    public bool active;
    public int activeLevel = 0;

    public enum difficult { DIFFICULT_EASY, DIFFICULT_MEDIUM, DIFFICULT_HARD };
    public difficult Difficult;

    public GameObject arena;

    void Start()
    {
        arena = gameObject.transform.GetChild(1).gameObject;
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
	}

    public void setActive(bool state)
    {
        if (state == true)
        {
            gameObject.SetActive(true);
            active = true;
        }
        else
        {
            gameObject.SetActive(false);
            active = false;
        }
    }

    public void setDifficult(difficult Diff)
    {
        Difficult = Diff;
    }
}
