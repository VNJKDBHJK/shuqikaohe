using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public Vector3 targetPosition;
    public string GameObjectTag;

    private void Update()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();

            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.tag == GameObjectTag)
                {
                    Transform clickedTransform = clickedCollider.transform;
                    // 将物体移动到指定位置
                    clickedTransform.position = targetPosition;
                    Static.isfish = true;

                }
            }

            if (Static.isfish)
            {
                GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(GameObjectTag);

                foreach (GameObject obj in targetObjects)
                {
                    // 销毁物体
                    Destroy(obj);
                }
            }
        }
    }

    private Collider2D GetClickedCollider()
    {
        // 发射一条射线，并获取点击的碰撞体
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // 检查点击的对象是否有碰撞体
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // 如果有碰撞体，则返回
                return clickedCollider;
            }
        }
        return null;
    }
}
