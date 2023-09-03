using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragiInfridge : MonoBehaviour
{
    public delegate void DrawerAction();//定义委托类型
    public static event DrawerAction OnDrawerOpen;//拉开的事件
    public static event DrawerAction OnDrawerClose;//关闭的事件

    private bool isOpen = false;

    private int ClickNum=0;
    private void OnEnable()
    {
        OnDrawerOpen += OpenDrawer;
        OnDrawerClose += CloseDrawer;
    }

    // 在脚本被禁用时取消注册事件
    private void OnDisable()
    {
        OnDrawerOpen -= OpenDrawer;
        OnDrawerClose -= CloseDrawer;
    }

    private void CloseDrawer()
    {
        isOpen = false;
    }

    private void OpenDrawer()
    {
        isOpen = true;
    }

    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            ClickNum++;
            Static.moveInFridge++;

            if (ClickNum % 2 == 1)
            {
                if (OnDrawerOpen != null)
                    OnDrawerOpen();
            }
            else if (ClickNum % 2 == 0)
            {
                if (OnDrawerClose != null)
                    OnDrawerClose();
            }
        }
    }
}
