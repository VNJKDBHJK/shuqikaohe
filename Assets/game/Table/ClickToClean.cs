using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToClean : MonoBehaviour
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
            if (Static.haveRag)
                if (Input.GetMouseButtonDown(0))
                {
                    // ��ȡ���λ������Ļ������
                    Vector3 mousePosition = Input.mousePosition;

                    // ����һ�����ߴӵ��λ�õ����������������������
                    Ray ray = Camera.main.ScreenPointToRay(mousePosition);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(123);
                        // �����ײ�Ƿ���ָ������ײ��
                        if (hit.collider == clickRange1)
                        {
                            Static.isclean = true;
                            Debug.Log("�����ָ����ײ����");
                        }
                    }
                }
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
            audioSource.PlayOneShot(click);
    }
}
