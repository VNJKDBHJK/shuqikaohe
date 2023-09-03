using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherSound : MonoBehaviour
{
    public float volumeDecreaseAmount;   // 音量降低的幅度
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HigherSoundOnClick()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume += volumeDecreaseAmount;
            audioSource.volume = Mathf.Clamp01(audioSource.volume);   // 确保音量在0到1之间
        }
    }
}
