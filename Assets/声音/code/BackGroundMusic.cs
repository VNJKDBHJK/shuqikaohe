using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public static BackGroundMusic instance;
    public AudioSource audioSource;

    void Start()
    {
            // 检查是否已经存在实例，如果存在则销毁新的实例
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            // 创建新的实例并确保不会被销毁
            instance = this;
            DontDestroyOnLoad(gameObject);

            // 获取音频源组件
            audioSource = GetComponent<AudioSource>();

            // 开始播放背景音乐

            audioSource.Play();
        }
    

}
