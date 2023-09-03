using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragInKitchen : MonoBehaviour
{
    public delegate void DrawerActionK();//����ί������
    public static event DrawerActionK OnDrawerOpenK;//�������¼�
    public static event DrawerActionK OnDrawerCloseK;//�رյ��¼�

    private bool isOpen = false;
    // �ڽű�������ʱע���¼�
    private void OnEnable()
    {
        OnDrawerOpenK += OpenDrawerK;
        OnDrawerCloseK += CloseDrawerK;
    }

    // �ڽű�������ʱȡ��ע���¼�
    private void OnDisable()
    {
        OnDrawerOpenK -= OpenDrawerK;
        OnDrawerCloseK -= CloseDrawerK;
    }

    private void CloseDrawerK()
    {
        isOpen = false;
    }

    private void OpenDrawerK()
    {
        isOpen = true;
    }

    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            Static.kitchen++;
            Debug.Log(Static.kitchen);
            if (Static.kitchen % 2 == 1)
            {
                if (OnDrawerOpenK != null)
                    OnDrawerOpenK();
            }
            else if (Static.kitchen % 2 == 0)
            {
                if (OnDrawerCloseK != null)
                    OnDrawerCloseK();
            }
        }
    }

    private void Update()
    {
        
    }
}
