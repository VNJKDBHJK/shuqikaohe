using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class picture123 : MonoBehaviour
{
    public Color targetColor;
    public Color targetColor2;
    public Color targetColor3;
    public Image image;   // 需要更改颜色的UI图像
    public bool is1;
    public bool is2;
    public bool is3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Static.Call);
        if (Static.CallOnClick)//done
            if(is1)
                image.color = targetColor;


        if (Static.isCanvas1)
            if (is2)
                image.color = targetColor2;


        if (Static.isCanvas2)//done
            if (is3)
            {
                Debug.Log(123);
                image.color = targetColor3;
            }
    }
}
