using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberTele : MonoBehaviour
{
    public int number;

    private AudioSource audioSource;
    public AudioClip click;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void NumberOnClick()
    {
        if (!Static.isPause)
        {
            audioSource.PlayOneShot(click);
            Display.Instance.ShowText(number);//运用到单例
        }
    }

}