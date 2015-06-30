using UnityEngine;
using System.Collections;

public class audioController : MonoBehaviour 
{
    public enum soundType { SOUND_BADSUDOKU }
    public AudioClip badSudokuSound;

    private AudioSource audioSrc;
	
	void Awake()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public void play(soundType type)
    {
        switch(type)
        {
            case soundType.SOUND_BADSUDOKU:
                audioSrc.PlayOneShot(badSudokuSound);
                break;
        }
    }
}
