using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click2 : MonoBehaviour
{
    private void Update()
    {
        if (!Static.isPause)
        {
            RaycastHit2D hit = GetRaycastHit2D();

            if (hit.collider != null)
            {
                Collider2D clickedCollider = hit.collider;

                if (clickedCollider.gameObject.CompareTag("Click"))
                {
                    Static.isclick = false;
                    Static.isclick2 = true;
                }
            }

            // 绘制射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);
        }
    }

    private RaycastHit2D GetRaycastHit2D()
    {
        // 发射射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        return hit;
    }
}
