using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragInKitchen : MonoBehaviour
{
    public delegate void DrawerActionK();//定义委托类型
    public static event DrawerActionK OnDrawerOpenK;//拉开的事件
    public static event DrawerActionK OnDrawerCloseK;//关闭的事件

    private bool isOpen = false;
    // 在脚本被启用时注册事件
    private void OnEnable()
    {
        OnDrawerOpenK += OpenDrawerK;
        OnDrawerCloseK += CloseDrawerK;
    }

    // 在脚本被禁用时取消注册事件
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
