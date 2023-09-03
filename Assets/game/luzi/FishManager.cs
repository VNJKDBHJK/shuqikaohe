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
                    // �������ƶ���ָ��λ��
                    clickedTransform.position = targetPosition;
                    Static.isfish = true;

                }
            }

            if (Static.isfish)
            {
                GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(GameObjectTag);

                foreach (GameObject obj in targetObjects)
                {
                    // ��������
                    Destroy(obj);
                }
            }
        }
    }

    private Collider2D GetClickedCollider()
    {
        // ����һ�����ߣ�����ȡ�������ײ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // ������Ķ����Ƿ�����ײ��
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // �������ײ�壬�򷵻�
                return clickedCollider;
            }
        }
        return null;
    }
}
