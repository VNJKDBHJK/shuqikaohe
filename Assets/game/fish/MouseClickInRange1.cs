using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickInRange1 : MonoBehaviour
{
    public Collider clickRange2;

    public GameObject clock;
    private AudioSource audioSource;
    public AudioClip click;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
            if (Static.haveknife)
            {
                if (Static.isknife2)
                {
                    clock.SetActive(true);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    // 获取点击位置在屏幕的坐标
                    Vector3 mousePosition = Input.mousePosition;

                    // 将点击位置转换为世界坐标
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    worldPosition.z = 0f; // 确保坐标在相机的视图平面上

                    if (clickRange2.bounds.Contains(worldPosition) && Static.isknife1)
                    {
                        Static.isknife2 = true;
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
