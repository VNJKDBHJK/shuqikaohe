using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject[] games;
    private int ClickNums = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject game in games)
        {
            game.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarOnClick()
    {
        ClickNums++;
        if (ClickNums % 2 == 1)
        {
            foreach (GameObject game in games)
            {
                game.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject game in games)
            {
                game.SetActive(false);
            }
        }
    }
}
