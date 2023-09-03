using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowerSound : MonoBehaviour
{
    public float volumeDecreaseAmount;   // �������͵ķ���
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LowerSoundOnClick()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume -= volumeDecreaseAmount; //ʹ��audioSource��volume���Ե�������
            audioSource.volume = Mathf.Clamp01(audioSource.volume);   // ȷ��������0��1֮��
        }
    }
}
