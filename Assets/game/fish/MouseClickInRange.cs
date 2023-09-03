using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickInRange : MonoBehaviour
{
    public Collider clickRange1;

    private AudioSource audioSource;
    public AudioClip click;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
            if (Static.haveknife)
                if (Input.GetMouseButtonDown(0))
                {
                    // ��ȡ���λ������Ļ������
                    Vector3 mousePosition = Input.mousePosition;

                    // �����λ��ת��Ϊ��������
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    worldPosition.z = 0f; // ȷ���������������ͼƽ����

                    // �����λ���Ƿ���ָ����Χ��
                    if (clickRange1.bounds.Contains(worldPosition))
                    {
                        Static.isknife1 = true;
                        Debug.Log("����ڷ�Χ��1");
                        // �ڷ�Χ��ִ������Ҫ�Ĳ���

                    }

                }
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
            audioSource.PlayOneShot(click);
    }
}
