using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickWindow : MonoBehaviour
{
    public Sprite[] images;
    private int ClickNum = 0;

    private AudioSource audioSource;
    public AudioClip click;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!Static.isPause)
        {
            // 检查鼠标左键点击事件
            if (Input.GetMouseButtonDown(0))
            {
                // 发射射线从鼠标位置
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // 检测射线与碰撞体的碰撞
                if (Physics.Raycast(ray, out hit))
                {
                    // 检查是否点击了指定的碰撞体
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        Static.WindowIsOpen = true;
                        ClickNum++;
                        Debug.Log(ClickNum);
                        audioSource.PlayOneShot(click);
                    }
                }
            }

            if (Static.WindowIsOpen)
            {

                if (ClickNum % 2 == 0)
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[0];
                }
                else
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[1];
                    Static.isopenWindow = true;
                }
            }
        }
    }
}
