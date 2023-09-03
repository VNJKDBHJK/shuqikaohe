using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NumberController : MonoBehaviour
{
    public delegate void LockBoxAction();//����ί������
    public static event LockBoxAction OnLockOpen;//�������¼�
    public static event LockBoxAction OnLockClose;//�رյ��¼�

    public Button[] button;
    public TMP_Text buttonText;
    public bool isclick=false;

    public GameObject Open;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    private static NumberController instance;

    private int is1949ed=0;
    private int is4169ed=0;
    private int is1977ed = 0;
    public GameObject Button;

    // ��ȡ����ʵ���ķ���
    public static NumberController Instance
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

    // �ڽű�������ʱȡ��ע���¼�
    private void OnDisable()
    {
        OnLockOpen -= OpenLock;
        OnLockClose -= CloseLock;
    }

    private void OpenLock()
    {
        buttonText.text = "RIGHT NUMBER";
        Open.SetActive(true);
        if (is1949ed==1)
        {
            GameObject newObj = Instantiate(prefab1, new Vector3(-7, -3.3f, 0), Quaternion.identity);
            is1949ed++;
        }

        if (is4169ed==1)
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

        if (button[0].GetComponent<number>().currentIndex == 1 && button[1].GetComponent<number>().currentIndex == 9 && button[2].GetComponent<number>().currentIndex == 4 && button[3].GetComponent<number>().currentIndex == 9)
        {
            is1949ed++;
            OpenLock();

        }
        else if (button[0].GetComponent<number>().currentIndex == 4 && button[1].GetComponent<number>().currentIndex == 1 && button[2].GetComponent<number>().currentIndex == 6 && button[3].GetComponent<number>().currentIndex == 9)
        {
            is4169ed++;
            OpenLock();
        }
        else if (button[0].GetComponent<number>().currentIndex == 1 && button[1].GetComponent<number>().currentIndex == 9 && button[2].GetComponent<number>().currentIndex == 7 && button[3].GetComponent<number>().currentIndex == 7)
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
