using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public GameObject text;
    private int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GroupOnClick()
    {
        num++;
        if (num % 2 == 1)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
