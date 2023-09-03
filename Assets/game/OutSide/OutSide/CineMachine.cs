using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachine : MonoBehaviour
{
    public Transform target;
    public float targetOrthographicSize;
    public float transitionDuration ;

    private CinemachineVirtualCamera CV;
    private float StartOrthoSize;
    private Vector3 StartPosition;
    public bool isturn;


    void Start()
    {
        CV = GetComponent<CinemachineVirtualCamera>();
        StartOrthoSize = CV.m_Lens.OrthographicSize;
        StartPosition = transform.position;
    }

    void Update()
    {
        if (isturn)
        {
            // 缩放相机
            float currentOrthographicSize = CV.m_Lens.OrthographicSize;
            float newOrthographicSize = Mathf.Lerp(currentOrthographicSize, targetOrthographicSize, transitionDuration * Time.deltaTime);
            CV.m_Lens.OrthographicSize = newOrthographicSize;

            // 移动相机
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = Vector3.Lerp(currentPosition, target.position, transitionDuration * Time.deltaTime);
            transform.position = newPosition;

            // 结束过渡
            if (Mathf.Approximately(currentOrthographicSize, targetOrthographicSize) && newPosition.Equals(target.position))
            {
                isturn = false;
            }
        }


    }

    public void Smooth()
    {
        // 启动过渡
        isturn = true;

        // 重置相机属性
        CV.m_Lens.OrthographicSize = StartOrthoSize;
        transform.position = StartPosition;
    }
}
