using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox2 : MonoBehaviour
{
    public Sprite[] images;
    public AudioClip audioClip;
    private bool audioPlayed = false;
    private void Update()
    {
        if (Static.isopen2)
        {
            if (!audioPlayed)
            {
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.Play();
                audioPlayed = true;
            }
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = images[1];
        }
        else
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = images[0];
        }
    }
}
