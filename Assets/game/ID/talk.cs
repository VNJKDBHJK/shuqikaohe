using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class talk : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mp3File;

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
        {
            PlayAudio();
            text.text = "This is my family .";
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
}
