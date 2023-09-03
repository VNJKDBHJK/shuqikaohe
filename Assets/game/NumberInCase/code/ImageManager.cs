using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public GameObject[] GameObjects;
    public bool is1949;

    public delegate void LockBoxAction();//定义委托类型
    public static event LockBoxAction OnLockOpen;//拉开的事件
    public static event LockBoxAction OnLockClose;//关闭的事件

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    private void Start()
    {

    }
    private void OnEnable()
    {
        OnLockOpen += OpenLock;
        OnLockClose += CloseLock;
    }

    // 在脚本被禁用时取消注册事件
    private void OnDisable()
    {
        OnLockOpen -= OpenLock;
        OnLockClose -= CloseLock;
    }

    private void OpenLock()
    {
        for(int i = 0; i < GameObjects.Length; i++)
        {
            Collider2D coll=GameObjects[i].GetComponent<Collider2D>();
            SpriteRenderer sr = GameObjects[i].GetComponent<SpriteRenderer>();
            coll.enabled = false;
            sr.enabled = false;
        }
        Static.isOpen = true;
    }

    private void CloseLock()
    {
        for (int i = 0; i < GameObjects.Length; i++)
        {
            Collider2D coll = GameObjects[i].GetComponent<Collider2D>();
            SpriteRenderer sr = GameObjects[i].GetComponent<SpriteRenderer>();
            coll.enabled = true;
            sr.enabled = true;
        }
        Static.isOpen = false;
    }

    private void Update()
    {
        if(GameObjects[0].GetComponent<ImageSWITCH>().currentIndex==1&&GameObjects[1].GetComponent<ImageSWITCH>().currentIndex==9&& GameObjects[2].GetComponent<ImageSWITCH>().currentIndex ==4&& GameObjects[3].GetComponent<ImageSWITCH>().currentIndex == 9)
        {
            OpenLock();
            if (Static.is1949ed == 1)
            {
                GameObject newObj = Instantiate(prefab1, new Vector3(-7, -3.3f, 0), Quaternion.identity);
                Static.is1949ed++;
            }
        }else if(GameObjects[0].GetComponent<ImageSWITCH>().currentIndex == 4 && GameObjects[1].GetComponent<ImageSWITCH>().currentIndex == 1 && GameObjects[2].GetComponent<ImageSWITCH>().currentIndex == 6 && GameObjects[3].GetComponent<ImageSWITCH>().currentIndex == 9)
        {
            OpenLock();
            if (Static.is4169ed == 1)
            {
                GameObject newObj = Instantiate(prefab2, new Vector3(-7, -3.3f, 0), Quaternion.identity);
                Static.is4169ed++;
            }
        }
        else if(GameObjects[0].GetComponent<ImageSWITCH>().currentIndex == 1 && GameObjects[1].GetComponent<ImageSWITCH>().currentIndex == 9 && GameObjects[2].GetComponent<ImageSWITCH>().currentIndex == 7 && GameObjects[3].GetComponent<ImageSWITCH>().currentIndex == 7)
        {
            OpenLock();
            if (Static.is1977ed == 1)
            {
                GameObject newObj = Instantiate(prefab3, new Vector3(-7, -3.3f, 0), Quaternion.identity);
                Static.is1977ed++;
            }
        }
        else
        {
            CloseLock();
        }
    }
}
