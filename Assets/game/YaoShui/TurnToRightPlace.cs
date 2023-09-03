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
                    // 将物体移动到指定位置
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
        // 发射一条射线，并获取点击的碰撞体
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // 检查点击的对象是否有碰撞体
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // 如果有碰撞体，则返回
                return clickedCollider;
            }
        }
        return null;
    }
}
