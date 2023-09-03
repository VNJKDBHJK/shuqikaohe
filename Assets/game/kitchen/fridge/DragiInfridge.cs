using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragiInfridge : MonoBehaviour
{
    public delegate void DrawerAction();//����ί������
    public static event DrawerAction OnDrawerOpen;//�������¼�
    public static event DrawerAction OnDrawerClose;//�رյ��¼�

    private bool isOpen = false;

    private int ClickNum=0;
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
