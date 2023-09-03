using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string Name;
    private AudioSource audioSource;
    public AudioClip click;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ExitOnClick()
    {
        if (!Static.isPause)
        {
            audioSource.PlayOneShot(click);
            SceneManager.LoadScene(Name);
        }
    }
}
