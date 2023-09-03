using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject minute;
    public GameObject Hour;

    public void BackOnClick()
    {
        if (!Static.isPause)
        {
            minute.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            Hour.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
