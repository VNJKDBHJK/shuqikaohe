using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickInRange : MonoBehaviour
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
            if (Static.haveknife)
                if (Input.GetMouseButtonDown(0))
                {
                    // 获取点击位置在屏幕的坐标
                    Vector3 mousePosition = Input.mousePosition;

                    // 将点击位置转换为世界坐标
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    worldPosition.z = 0f; // 确保坐标在相机的视图平面上

                    // 检查点击位置是否在指定范围内
                    if (clickRange1.bounds.Contains(worldPosition))
                    {
                        Static.isknife1 = true;
                        Debug.Log("点击在范围内1");
                        // 在范围内执行你想要的操作

                    }

                }
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
            audioSource.PlayOneShot(click);
    }
}
