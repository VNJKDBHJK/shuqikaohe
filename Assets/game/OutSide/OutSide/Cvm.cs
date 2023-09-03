using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cvm : MonoBehaviour
{
    public Transform target;
    public float targetOrthographicSize;
    public float transitionDuration;

    private CinemachineVirtualCamera CV;
    private float StartOrthoSize;
    private Vector3 StartPosition;
    public bool isturn;
    public bool isback;

    public bool iswindow1;


    void Start()
    {
        CV = GetComponent<CinemachineVirtualCamera>();
        StartOrthoSize = 10;
        StartPosition = transform.position;
        if (iswindow1)
        {
            isturn = true;
        }
    }

    void Update()
    {
        if (Static.isclick)
            isback = true;
        else isback = false;

        if (Static.isclick2)
            isturn = true;
        else isturn = false;
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

        if (isback)
        {
            
            isturn = false;
            // 缩放相机
            float currentOrthographicSize = CV.m_Lens.OrthographicSize;
            float newOrthographicSize = Mathf.Lerp(currentOrthographicSize, StartOrthoSize, transitionDuration * Time.deltaTime);
            CV.m_Lens.OrthographicSize = newOrthographicSize;

            // 移动相机
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = Vector3.Lerp(currentPosition, StartPosition, transitionDuration * Time.deltaTime);
            transform.position = newPosition;

            // 结束过渡
            if (Mathf.Approximately(currentOrthographicSize, StartOrthoSize) && newPosition.Equals(StartPosition))
            {
                isback = false;
                CV.m_Lens.OrthographicSize = StartOrthoSize;
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
