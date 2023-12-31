using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeManager : MonoBehaviour
{
    public delegate void LockBoxAction();//定义委托类型
    public static event LockBoxAction OnLockOpen;//拉开的事件
    public static event LockBoxAction OnLockClose;//关闭的事件

    public GameObject[] gameObjects;
    public TMP_Text buttonText;
    public bool isclick = false;

    public GameObject Open;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    private static ChangeManager instance;

    private int is1949ed = 0;
    private int is4169ed = 0;
    private int is1977ed = 0;
    public GameObject Button;

    // 获取单例实例的方法
    public static ChangeManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

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
        buttonText.text = "RIGHT NUMBER";
        Open.SetActive(true);
        if (is1949ed == 1)
        {
            GameObject newObj = Instantiate(prefab1, new Vector3(-7, -3.3f, 0), Quaternion.identity);
            is1949ed++;
        }

        if (is4169ed == 1)
        {
            GameObject newObj = Instantiate(prefab2, new Vector3(-7, -3.3f, 0), Quaternion.identity);
            is4169ed++;
        }

        if (is1977ed == 1)
        {
            GameObject newObj = Instantiate(prefab3, new Vector3(-7, -3.3f, 0), Quaternion.identity);
            is1977ed++;
        }
        isclick = true;
        Button.SetActive(true);
        Static.isdone = true;
    }

    private void CloseLock()
    {
        isclick = false;
        Open.SetActive(false);
        buttonText.text = "LOCK";
        Static.isdone = false;
    }

    private void Update()
    {
        
        
            OnClick();
        
    }

    public void OnClick()
    {
        if (isclick)
        {
            CloseLock();
        }

        if (Static.ifButton)
        {
            Button.SetActive(false);
        }

        if (gameObjects[0].GetComponent<number>().currentIndex == 1 && gameObjects[1].GetComponent<number>().currentIndex == 9 && gameObjects[2].GetComponent<number>().currentIndex == 4 && gameObjects[3].GetComponent<number>().currentIndex == 9)
        {
            is1949ed++;
            OpenLock();

        }
        else if (gameObjects[0].GetComponent<number>().currentIndex == 4 && gameObjects[1].GetComponent<number>().currentIndex == 1 && gameObjects[2].GetComponent<number>().currentIndex == 6 && gameObjects[3].GetComponent<number>().currentIndex == 9)
        {
            is4169ed++;
            OpenLock();
        }
        else if (gameObjects[0].GetComponent<number>().currentIndex == 1 && gameObjects[1].GetComponent<number>().currentIndex == 9 && gameObjects[2].GetComponent<number>().currentIndex == 7 && gameObjects[3].GetComponent<number>().currentIndex == 7)
        {
            is1977ed++;
            OpenLock();
        }
        else
        {
            buttonText.text = "ERROR NUMBER";
            Open.SetActive(false);
            Button.SetActive(false);
        }

    }
}
