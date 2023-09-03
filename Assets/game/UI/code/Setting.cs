using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    public AudioClip Click;
    private AudioSource audioSource;

    private int ClickNums=0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        go1.SetActive(false);
        go2.SetActive(false);
        go3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingOnClick()
    {
        audioSource.PlayOneShot(Click);
        ClickNums++;
        if (ClickNums % 2 == 1)
        {
            go1.SetActive(true);
            go2.SetActive(true);
            go3.SetActive(true);
        }
        else
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
        }
    }
}
