using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mirror : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mp3File;
    public AudioClip mp3File1;

    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mirrorOnClick()
    {
        if (!Static.isPause)
            if (!Static.Call)
            {
                PlayAudio();
                text.text = "I need to obtain some items to prepare the potion .";
            }
            else
            {
                PlayAudio1();
                text.text = "Perhaps Uncle Benjamin should have called";
                Static.CallOnClick = true;
            }
        
    }
    public void PlayAudio()
    {
        if (audioSource != null && mp3File != null)
        {
            audioSource.clip = mp3File;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }

    public void PlayAudio1()
    {
        if (audioSource != null && mp3File1 != null)
        {
            audioSource.clip = mp3File1;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }
}
