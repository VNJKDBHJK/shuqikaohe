using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStatic : MonoBehaviour
{
    private static OpenStatic instance;

    public static OpenStatic Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
