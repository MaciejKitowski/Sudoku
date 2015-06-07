using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class movesController : MonoBehaviour 
{
    private Text text;
	
	void Start () 
    {
        text = gameObject.GetComponent<Text>();
	}
	
	void Update () 
    {
        text.text = gameManager.moves.ToString();
	}
}
