using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private Vector3 targetPosition;
    public float moveSpeed = 2f;
    public Vector3 targetPosition1;
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
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击的位置
            audioSource.PlayOneShot(Click);
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z; // 如果3D场景的话，将z坐标设置为当前物体的z坐标
            hasTriggeredAudio = true;
        }

        // 当前位置向目标位置平滑移动
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(targetPosition1, targetPosition) <= 0.5f)
        {
            SceneManager.LoadScene("0101");
        }
    }
}
