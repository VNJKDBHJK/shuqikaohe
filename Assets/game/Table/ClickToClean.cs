using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToClean : MonoBehaviour
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
            if (Static.haveRag)
                if (Input.GetMouseButtonDown(0))
                {
                    // 获取点击位置在屏幕的坐标
                    Vector3 mousePosition = Input.mousePosition;

                    // 发射一条射线从点击位置到摄像机所看到的世界坐标
                    Ray ray = Camera.main.ScreenPointToRay(mousePosition);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(123);
                        // 检查碰撞是否是指定的碰撞器
                        if (hit.collider == clickRange1)
                        {
                            Static.isclean = true;
                            Debug.Log("点击在指定碰撞器内");
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
