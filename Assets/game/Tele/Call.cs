using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;//SequenceEqualÍ·ÎÄ¼þ
using TMPro;

public class Call : MonoBehaviour
{
    public int[] str1;
    public int[] str2;

    public AudioSource audioSource;
    public AudioClip mp3File;
    public AudioClip call;

    public TMP_Text text;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CallOnClick()
    {
        if (!Static.isPause)
        {
            if (Display.Instance.numberArray.SequenceEqual(str1))
            {
                //Event1
                PlayAudio();
                text.text = "Check the drawer next to the sofa in the right room.";
                Static.iscall1 = true;
            }
            else if (Display.Instance.numberArray.SequenceEqual(str2))
            {
                //Event2
            }
            else
            {
                audioSource.PlayOneShot(call);
                Display.Instance.NullNumber();
                text.text = " ";
            }
        }
    }

    public void PlayAudio()
    {
        if (audioSource != null && mp3File != null)
        {
            audioSource.clip = mp3File;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }

    public void IsRight()
    {
        
    }
}
