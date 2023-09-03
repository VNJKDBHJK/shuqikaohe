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

            // 遍历所有找到的物体，并将它们的audio组件的enabled属性设为false
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

            // 遍历所有找到的物体，并将它们的audio组件的enabled属性设为false
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
