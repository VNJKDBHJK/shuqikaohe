using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOnDrag : MonoBehaviour
{
    public delegate void DrawerAction();//定义委托类型
    public static event DrawerAction OnDrawerOpen;//拉开的事件
    public static event DrawerAction OnDrawerClose;//关闭的事件

    private bool isOpen = false;
    private int[] clickCount = new int[] { 0, 0, 0, 0, 0 };
    public int ID;

    public bool isid;
    public GameObject turntoid;

    // 在脚本被启用时注册事件
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
        clickCount[ID]++;
        Static.movecasenumber[ID]++;

        if (clickCount[ID] % 2 == 1)
        {
            if (OnDrawerOpen != null)
                OnDrawerOpen();
        }
        else if (clickCount[ID] % 2 == 0)
        {
            if (OnDrawerClose != null)
                OnDrawerClose();
        }
    }
}
