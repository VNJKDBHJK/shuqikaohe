using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOn : MonoBehaviour
{
    public Button button;
    public Sprite[] images;
    private int ClickNums=0;
    private Image ButtonImage;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        ButtonImage = button.GetComponent<Image>();
        ButtonImage.sprite = images[0];
        audio = BackGroundMusic.instance.audioSource;
        audio.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MusicOnClick()
    {
        ClickNums++;
        if (ClickNums % 2 == 1)
        {
            //MusicOff
            GameObject[] qweObjects = GameObject.FindGameObjectsWithTag("music");

            // ���������ҵ������壬�������ǵ�audio�����enabled������Ϊfalse
            foreach (GameObject qweObject in qweObjects)
            {
                AudioSource audioSource = qweObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.enabled = false;
                }
            }
            ButtonImage.sprite = images[1];

        }
        else
        {
            //MusicOn
            GameObject[] qweObjects = GameObject.FindGameObjectsWithTag("music");

            // ���������ҵ������壬�������ǵ�audio�����enabled������Ϊfalse
            foreach (GameObject qweObject in qweObjects)
            {
                AudioSource audioSource = qweObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.enabled = true;
                }
            }
            ButtonImage.sprite = images[0];
        }
    }
}
