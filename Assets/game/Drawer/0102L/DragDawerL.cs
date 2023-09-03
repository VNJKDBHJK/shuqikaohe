using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDawerL : MonoBehaviour
{
    public delegate void DrawerAction2();//定义委托类型
    public static event DrawerAction2 OnDrawerOpen2;//拉开的事件
    public static event DrawerAction2 OnDrawerClose2;//关闭的事件

    private bool isOpen = false;
    private int clickCount=0;

    // 在脚本被启用时注册事件
    private void OnEnable()
    {
        OnDrawerOpen2 += OpenDrawer2;
        OnDrawerClose2 += CloseDrawer2;
    }

    // 在脚本被禁用时取消注册事件
    private void OnDisable()
    {
        OnDrawerOpen2 -= OpenDrawer2;
        OnDrawerClose2 -= CloseDrawer2;
    }

    private void CloseDrawer2()
    {
        isOpen = false;
    }

    private void OpenDrawer2()
    {
        isOpen = true;
    }

    private void OnMouseDown()
    {
        clickCount++;
        Static.movecaseNumber++;

        if (clickCount % 2 == 1)
        {
            if (OnDrawerOpen2 != null)
                OnDrawerOpen2();
        }
        else if (clickCount % 2 == 0)
        {
            if (OnDrawerClose2 != null)
                OnDrawerClose2();
        }
    }
}
