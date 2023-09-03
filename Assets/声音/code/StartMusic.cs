using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMusic : MonoBehaviour
{
    public AudioClip musicClip;

    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        // ��ȡ����������
        string sceneName = currentScene.name;
        if (sceneName == "0000" && !hasPlayed)
        {
            PlayMusic();
            hasPlayed = true;
        }
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }
}
