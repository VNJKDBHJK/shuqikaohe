using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagOnDrag : MonoBehaviour,IDragHandler
{
    RectTransform currentTransform;

    public void OnDrag(PointerEventData eventData)
    {
        currentTransform.anchoredPosition += eventData.delta;//中心锚点加鼠标移动值
    }

    private void Awake()
    {
        currentTransform = GetComponent<RectTransform>();
    }
}
