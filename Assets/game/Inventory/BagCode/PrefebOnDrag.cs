using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefebOnDrag : MonoBehaviour
{
    public bool isDragging=false;
    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // 保持物体的Z轴不变
            transform.position = mousePosition;
        }
    }
    private void OnMouseUp()
    {
        isDragging = false;

    }
}
