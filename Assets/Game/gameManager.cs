using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
    public static numpadController numpad;
    public static float timer;
    public static int moves;
    
	
	void Awake()
    {
        timer = 0.0f;
        moves = 0;

        numpad = FindObjectOfType<numpadController>();
        numpad.gameObject.SetActive(false);
    }
	
	void Update () 
    {
        timer += Time.deltaTime;
	}
}
