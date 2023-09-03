using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhazhiButton : MonoBehaviour
{
    private int ClickNum = 0;
    private float Rotation = 0f;
    public float Speed = 3f;

    private bool isRotating = false;
    private bool isRotatinged = false;

    public GameObject appleJuice;
    public GameObject flowerJuice;
    public GameObject orangeJuice;

    public AudioClip Click;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;
    }

    void Update()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("item"))
                {
                    if (clickedCollider.gameObject.name == "apple(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        GameObject newObj = Instantiate(appleJuice, new Vector3(-13.12f, 2.81f, 0), Quaternion.identity);
                        Destroy(GameObject.Find("apple(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "flower(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        GameObject newObj = Instantiate(flowerJuice, new Vector3(-13.12f, 2.81f, 0), Quaternion.identity);
                        Destroy(GameObject.Find("flower(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "orange(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        GameObject newObj = Instantiate(orangeJuice, new Vector3(-13.12f, 2.81f, 0), Quaternion.identity);
                        Destroy(GameObject.Find("orange(Clone)"));
                        hasTriggeredAudio = true;
                    }
                }

            }


            if (isRotating)
            {
                Rotation += Speed * Time.deltaTime;

                if (Rotation >= 180f)
                {
                    Rotation = 180f;
                    isRotating = false;
                }

                transform.rotation = Quaternion.Euler(0f, 0f, Rotation);
            }

            if (isRotatinged)
            {
                Rotation -= Speed * Time.deltaTime;

                if (Rotation <= 0f)
                {
                    Rotation = 0f;
                    isRotatinged = false;
                }

                transform.rotation = Quaternion.Euler(0f, 0f, Rotation);
            }
        }

    }

    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            ClickNum++;


            if (ClickNum % 2 == 1)
            {
                Static.isOpenInZhazhi = true;
                isRotating = true;
            }
            else
            {
                Static.isOpenInZhazhi = false;
                isRotatinged = true;
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
