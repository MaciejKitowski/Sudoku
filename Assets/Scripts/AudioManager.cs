using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

    [SerializeField] private AudioSource[] SFXs;

    private void Awake(){
    	if(Instance == null) {
    		DontDestroyOnLoad(this.gameObject);
    		Instance = this;
    	} 
    }

    public void PlaySFX(int index){
    	if(PlayerPrefs.GetInt("sound") == 1)
    		SFXs[index].Play();
    }
}
