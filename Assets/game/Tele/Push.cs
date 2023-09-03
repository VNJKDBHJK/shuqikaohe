using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public GameObject page01;
    public GameObject Page1;
    public GameObject page02;
    public GameObject Page2;
    public GameObject page03;
    public GameObject Page3;
    public GameObject page04;
    public GameObject Page4;

    public bool ispage1;
    public bool ispage2;
    public bool ispage3;
    public bool ispage4;

    public void ButtonOnClick()
    {
        if (!Static.isPause)
        {
            if (ispage1)
            {
                Debug.Log(ispage1);
                page01.SetActive(true);
                Page1.SetActive(false);
                page02.SetActive(false);
                Page2.SetActive(true);
                page03.SetActive(false);
                Page3.SetActive(true);
                page04.SetActive(false);
                Page4.SetActive(true);
            }

            if (ispage2)
            {
                page01.SetActive(false);
                Page1.SetActive(true);
                page02.SetActive(true);
                Page2.SetActive(false);
                page03.SetActive(false);
                Page3.SetActive(true);
                page04.SetActive(false);
                Page4.SetActive(true);
            }

            if (ispage3)
            {
                page01.SetActive(false);
                Page1.SetActive(true);
                page02.SetActive(false);
                Page2.SetActive(true);
                page03.SetActive(true);
                Page3.SetActive(false);
                page04.SetActive(false);
                Page4.SetActive(true);
            }

            if (ispage4)
            {
                page01.SetActive(false);
                Page1.SetActive(true);
                page02.SetActive(false);
                Page2.SetActive(true);
                page03.SetActive(false);
                Page3.SetActive(true);
                page04.SetActive(true);
                Page4.SetActive(false);
            }
        }
    }
}
