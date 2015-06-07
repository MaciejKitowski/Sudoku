using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
    public static numpadController numpad;
    
	
	void Awake()
    {
        numpad = FindObjectOfType<numpadController>();
        numpad.gameObject.SetActive(false);
    }
	
	
	void Update () 
    {
	
	}
}
