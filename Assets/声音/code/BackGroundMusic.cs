using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public static BackGroundMusic instance;
    public AudioSource audioSource;

    void Start()
    {
            // ����Ƿ��Ѿ�����ʵ������������������µ�ʵ��
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            // �����µ�ʵ����ȷ�����ᱻ����
            instance = this;
            DontDestroyOnLoad(gameObject);

            // ��ȡ��ƵԴ���
            audioSource = GetComponent<AudioSource>();

            // ��ʼ���ű�������

            audioSource.Play();
        }
    

}
