using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEXT : MonoBehaviour
{
    public GameObject[] games;
    private int number = 0;
    public AudioClip Click;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        games[0].SetActive(true);
        games[1].SetActive(false);
        games[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickOnButton()
    {
        audioSource.PlayOneShot(Click);
        number++;
        games[number-1].SetActive(false);
        if (number == 3)
        {
            number = 0;
        }
        games[number].SetActive(true);
    }
}
