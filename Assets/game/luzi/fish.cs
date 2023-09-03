using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    public Sprite[] images;
    public GameObject redfish;

    private AudioSource audioSource;
    public AudioClip Fish;
    public AudioClip FryFish;
    public AudioClip Fire;
    private bool isPlayingAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        redfish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            if (Static.haveFire && !Static.isfinish)
            {
                if (!isPlayingAudio)
                {
                    audioSource.clip = Fire;
                    audioSource.Play();
                    isPlayingAudio = true;
                }
            }
            if (Static.isfish)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[1];
                if (!isPlayingAudio)
                {
                    audioSource.clip = Fish;
                    audioSource.Play();
                    isPlayingAudio = true;
                }
                if (Static.haveFire)
                {
                    spriteRenderer.sprite = images[2];
                    redfish.SetActive(true);
                    if (!isPlayingAudio)
                    {
                        audioSource.clip = FryFish;
                        audioSource.Play();
                        isPlayingAudio = true;
                    }
                }
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
            }
        }
    }
}