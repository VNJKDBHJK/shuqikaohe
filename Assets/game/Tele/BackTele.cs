using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTele : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip click;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void BackOnClick()
    {
        audioSource.PlayOneShot(click);
        Display.Instance.RemoveLastElementFromArray();
    }

}
