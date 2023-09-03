using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOnDragg : MonoBehaviour
{
    public delegate void DrawerAction2();//����ί������
    public static event DrawerAction2 OnDrawerOpen2;//�������¼�
    public static event DrawerAction2 OnDrawerClose2;//�رյ��¼�

    private bool isOpen = false;
    private int[] clickCount = new int[] { 0, 0, 0, 0, 0 };
    public int ID;

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
        if (!Static.isPause)
        {
            clickCount[ID]++;
            Static.movecasenumber2[ID]++;

            if (clickCount[ID] % 2 == 1)
            {
                if (OnDrawerOpen2 != null)
                    OnDrawerOpen2();
            }
            else if (clickCount[ID] % 2 == 0)
            {
                if (OnDrawerClose2 != null)
                    OnDrawerClose2();
            }
        }
    }
}
