using UnityEngine;
using System.Collections;

public class audioController : MonoBehaviour 
{
    public enum soundType { SOUND_BADSUDOKU, SOUND_GOODSUDOKU, SOUND_BUTTONCLICK }
    public AudioClip badSudokuSound;
    public AudioClip goodSudokuSound;
    public AudioClip buttonClickSound;

    private AudioSource audioSrc;
	
	void Awake()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public void play(soundType type = soundType.SOUND_BUTTONCLICK)
    {
        if(!Settings.soundMute)
        {
            switch (type)
            {
                case soundType.SOUND_BADSUDOKU:
                    audioSrc.PlayOneShot(badSudokuSound);
                    break;
                case soundType.SOUND_GOODSUDOKU:
                    audioSrc.PlayOneShot(goodSudokuSound);
                    break;
                case soundType.SOUND_BUTTONCLICK:
                    audioSrc.PlayOneShot(buttonClickSound);
                    break;
            }
        }
    }
}
