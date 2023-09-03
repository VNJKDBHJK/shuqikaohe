using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;

    private bool isMousePressed = false;
    private float mouseClickStartTime = 0f;

    public GameObject prefab;
    private AudioSource audioSource;
    public AudioClip click;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Static.isPause)
        {
            Debug.Log(Static.islightened);
            if (isMousePressed)
            {
                float mouseClickDuration = Time.time - mouseClickStartTime;
                if (mouseClickDuration >= 2f)
                {
                    Static.islightened = true;
                    isMousePressed = false;
                }
            }

            Collider2D clickedCollider = GetClickedCollider();
            if (Static.islightened)
                if (clickedCollider != null)
                {
                    if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("item"))
                    {
                        if (clickedCollider.gameObject.name == "EmptyLeyden(Clone)" && Static.isllightenone == 1)
                        {
                            GameObject newObj = Instantiate(prefab, new Vector3(-13.61f, -8.61f, 0), Quaternion.identity);
                            Static.isllightenone++;
                            Destroy(GameObject.Find("EmptyLeyden(Clone)"));
                        }
                    }
                }
        }
    }

    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            audioSource.PlayOneShot(click);
            sr.enabled = true;
            // 触发动画播放
            animator.SetTrigger("ANIM");

            isMousePressed = true;
            mouseClickStartTime = Time.time;
        }
    }
    private void OnMouseUp()
    {
        if (!Static.isPause)
        {
            sr.enabled = false;
            animator.SetTrigger("idle");
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
