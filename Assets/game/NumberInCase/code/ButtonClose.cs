using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PictureOpen;
    private static ButtonClose instance;
    public static ButtonClose Instance
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
    public void ButtonOnClick()
    {
        Static.isdone = false;
        PictureOpen.SetActive(false);
        Canvas.SetActive(true);
        Static.ifButton = true;
    }
}
