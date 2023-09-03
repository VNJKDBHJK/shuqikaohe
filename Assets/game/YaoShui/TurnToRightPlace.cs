using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToRightPlace : MonoBehaviour
{
    public Vector3 targetPosition;
    public string GameObjectTag;
    public bool isred;
    public bool isgreen;
    public bool isblue;

    public AudioClip Click;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;
    }

    private void Update()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();

            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.tag == GameObjectTag)
                {
                    Transform clickedTransform = clickedCollider.transform;
                    // �������ƶ���ָ��λ��
                    clickedTransform.position = targetPosition;
                    if (isred)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isreded = true;
                        hasTriggeredAudio = true;
                    }


                    if (isblue)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isblueed = true;
                        hasTriggeredAudio = true;
                    }


                    if (isgreen)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isgreened = true;
                        hasTriggeredAudio = true;
                    }

                }
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
}
