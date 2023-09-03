using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSWITCH : MonoBehaviour
{
    public Sprite[] images;
    public int currentIndex = 0;

    private AudioSource audioSource;
    public AudioClip click;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            audioSource.PlayOneShot(click);
            // ��ȡ�������ײ��
            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
            {
                // �л�����ײ�����������ͼ��
                SwitchImage(clickedCollider.gameObject);
            }
        }
    }

    private Collider2D GetClickedCollider()
    {
        // ����һ�����ߣ�����ȡ�������ײ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // ������Ķ����Ƿ�����ײ��
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // �������ײ�壬�򷵻�
                return clickedCollider;
            }
        }
        return null;
    }

    private void SwitchImage(GameObject obj)
    {
        // ��ȡ������� SpriteRenderer ���
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // �л�����һ��ͼ��
            currentIndex = (currentIndex + 1) % images.Length;
            spriteRenderer.sprite = images[currentIndex];
        }
    }
}
