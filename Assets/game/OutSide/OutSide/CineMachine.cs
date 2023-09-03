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
            // �������
            float currentOrthographicSize = CV.m_Lens.OrthographicSize;
            float newOrthographicSize = Mathf.Lerp(currentOrthographicSize, targetOrthographicSize, transitionDuration * Time.deltaTime);
            CV.m_Lens.OrthographicSize = newOrthographicSize;

            // �ƶ����
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = Vector3.Lerp(currentPosition, target.position, transitionDuration * Time.deltaTime);
            transform.position = newPosition;

            // ��������
            if (Mathf.Approximately(currentOrthographicSize, targetOrthographicSize) && newPosition.Equals(target.position))
            {
                isturn = false;
            }
        }


    }

    public void Smooth()
    {
        // ��������
        isturn = true;

        // �����������
        CV.m_Lens.OrthographicSize = StartOrthoSize;
        transform.position = StartPosition;
    }
}
