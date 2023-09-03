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
            // 获取点击的碰撞体
            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
            {
                // 切换该碰撞体所属物体的图像
                SwitchImage(clickedCollider.gameObject);
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

    private void SwitchImage(GameObject obj)
    {
        // 获取该物体的 SpriteRenderer 组件
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // 切换到下一个图像
            currentIndex = (currentIndex + 1) % images.Length;
            spriteRenderer.sprite = images[currentIndex];
        }
    }
}
