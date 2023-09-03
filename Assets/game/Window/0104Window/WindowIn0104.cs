using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowIn0104 : MonoBehaviour
{
    public Sprite[] images;
    private int ClickNum = 0;
    private AudioSource audioSource;
    public AudioClip click;
    public AudioClip click1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!Static.isPause)
        {
            // �������������¼�
            if (Input.GetMouseButtonDown(0))
            {
                // �������ߴ����λ��
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // �����������ײ�����ײ
                if (Physics.Raycast(ray, out hit))
                {
                    // ����Ƿ�����ָ������ײ��
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        Static.WindowIsOpen = true;
                        ClickNum++;
                        Debug.Log(ClickNum);
                    }
                }
            }

            if (Static.WindowIsOpen)
            {
                if (ClickNum % 2 == 0)
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[0];
                    Static.isopenWindow0104 = false;
                }
                else
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[1];
                    Static.isopenWindow0104 = true;
                }
            }
        }
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
            if (ClickNum % 2 == 1)
            {
                audioSource.PlayOneShot(click);
            }
            else
            {
                audioSource.PlayOneShot(click1);
            }
    }
}
