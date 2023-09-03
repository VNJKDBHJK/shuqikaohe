using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caozuozhinan : MonoBehaviour
{
    public GameObject caozuo;
    private int clickNum=0;
    public AudioClip Click;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        caozuo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickOnButton()
    {
        audioSource.PlayOneShot(Click);
        clickNum++;
        if (clickNum % 2 == 1)
        {
            caozuo.SetActive(true);
        }
        else
        {
            caozuo.SetActive(false);
        }
    }
}
