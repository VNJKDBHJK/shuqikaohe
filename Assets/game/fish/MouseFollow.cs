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
                    // ��ȡ�������Ļ��λ��
                    Vector3 mousePosition = Input.mousePosition;

                    // �������Ļ����ת��Ϊ��������
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    worldPosition.z = 0f; // ȷ���������������ͼƽ����

                    // ��������λ��Ϊ�����������
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
