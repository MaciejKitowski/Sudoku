using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class areaController : MonoBehaviour 
{

	
	void Start () 
    {
	
	}
	
	
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        Debug.Log(gameObject.transform.parent.transform.parent.name + " - " + gameObject.name);
    }
}
