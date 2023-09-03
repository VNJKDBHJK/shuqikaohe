using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PicManger : MonoBehaviour
{
    public GameObject front;
    public GameObject back;
    public GameObject text;

    private bool isready;
    public int ClickNumber=0;

    public AudioClip Click;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;
        front.SetActive(false);
        back.SetActive(false);
        text.SetActive(false);
    }
    private void Update()
    {
        if (!Static.isPause)
        {
            if (Static.isPic1 && Static.isPic2 && Static.isPic3 && Static.isPic4 && Static.isPic5 && Static.isPic6)
            {
                isready = true;
                Static.isCanvas1 = true;
            }
            if (isready)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.PlayOneShot(Click);
                    ClickNumber++;
                    if (ClickNumber % 2 == 1)
                    {
                        back.SetActive(false);
                        text.SetActive(false);
                        front.SetActive(true);
                    }
                    else
                    {
                        front.SetActive(false);
                        back.SetActive(true);
                        text.SetActive(true);
                        hasTriggeredAudio = true;
                    }
                }
            }
        }
    }

}
