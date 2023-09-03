using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagOnDrag : MonoBehaviour,IDragHandler
{
    RectTransform currentTransform;

    public void OnDrag(PointerEventData eventData)
    {
        currentTransform.anchoredPosition += eventData.delta;//����ê�������ƶ�ֵ
    }

    private void Awake()
    {
        currentTransform = GetComponent<RectTransform>();
    }
}
