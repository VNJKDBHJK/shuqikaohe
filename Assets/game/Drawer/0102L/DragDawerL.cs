using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDawerL : MonoBehaviour
{
    public delegate void DrawerAction2();//����ί������
    public static event DrawerAction2 OnDrawerOpen2;//�������¼�
    public static event DrawerAction2 OnDrawerClose2;//�رյ��¼�

    private bool isOpen = false;
    private int clickCount=0;

    // �ڽű�������ʱע���¼�
    private void OnEnable()
    {
        OnDrawerOpen2 += OpenDrawer2;
        OnDrawerClose2 += CloseDrawer2;
    }

    // �ڽű�������ʱȡ��ע���¼�
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
