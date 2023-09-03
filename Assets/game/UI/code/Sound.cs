using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private int numOfGame=0;
    public GameObject GAME1;
    public GameObject GAME2;
    // Start is called before the first frame update
    void Start()
    {
        GAME1.SetActive(false);
        GAME2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SoundOnClick()
    {
        numOfGame++;

        if (numOfGame % 2 == 1)
        {
            GAME1.SetActive(true);
            GAME2.SetActive(true);
        }
        else
        {
            GAME1.SetActive(false);
            GAME2.SetActive(false);
        }
    }
}
