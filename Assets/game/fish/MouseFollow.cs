using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            Debug.Log(Static.haveknife);

            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("item"))
                {
                    if (clickedCollider.gameObject.name == "knife(Clone)")
                    {
                        Static.haveknife = true;
                        Destroy(GameObject.Find("knife(Clone)"));
                    }
                }
            }


            if (Static.haveknife)
            {
                sr.enabled = true;
                if (!Static.isknife2)
                {
                    // 获取鼠标在屏幕的位置
                    Vector3 mousePosition = Input.mousePosition;

                    // 将鼠标屏幕坐标转换为世界坐标
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    worldPosition.z = 0f; // 确保物体在相机的视图平面上

                    // 设置物体位置为鼠标世界坐标
                    transform.position = worldPosition;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                sr.enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        
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
