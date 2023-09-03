using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOnDrag : MonoBehaviour
{
    public delegate void DrawerAction();//����ί������
    public static event DrawerAction OnDrawerOpen;//�������¼�
    public static event DrawerAction OnDrawerClose;//�رյ��¼�

    private bool isOpen = false;
    private int[] clickCount = new int[] { 0, 0, 0, 0, 0 };
    public int ID;

    public bool isid;
    public GameObject turntoid;

    // �ڽű�������ʱע���¼�
    private void OnEnable()
    {
        OnDrawerOpen += OpenDrawer;
        OnDrawerClose += CloseDrawer;
    }

    // �ڽű�������ʱȡ��ע���¼�
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
