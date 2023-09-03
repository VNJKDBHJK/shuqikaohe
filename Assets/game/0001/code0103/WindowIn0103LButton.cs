using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowIn0103LButton : MonoBehaviour
{
    private int ClickNum=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOnClick()
    {
        ClickNum++;
        if (Static.isC2)
        {
            if (ClickNum % 2 == 1&&Static.isC2sNum==0)
            {
                Static.iscanvas2 = true;
                Static.isCanvas2 = true;
                Static.isC2sNum++;
            }
            else
            {
                Static.iscanvas2 = false;
            }
        }
    }
}
