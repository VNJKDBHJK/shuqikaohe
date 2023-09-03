using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaoshuiInstan : MonoBehaviour
{
    public GameObject prefab;
    public AudioClip Click;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;
    }
    private void Update()
    {
        if (!Static.isPause)
        {
            if (Static.isreded && Static.isgreened && Static.isblueed && Static.isone == 1)
            {
                audioSource.PlayOneShot(Click);
                GameObject newObj = Instantiate(prefab, new Vector3(-7, -8f, 0), Quaternion.identity);
                Static.isone++;
                hasTriggeredAudio = true;
            }
        }
    }
}
