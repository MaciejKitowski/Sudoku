using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectLevelArenaController : MonoBehaviour 
{
    private GameObject[] area;
	
	void Start () 
    {
        area = new GameObject[81];

        for(int i = 0; i < 81; ++i)
        {
            area[i] = gameObject.transform.GetChild(i).gameObject;
        }
	}
	
	public void setValue(int areaNumber, string value)
    {
        area[areaNumber].GetComponentInChildren<Text>().text = value;
    }
}
