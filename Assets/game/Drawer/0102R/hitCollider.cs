using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCollider : MonoBehaviour
{
    public LayerMask hitLayer;
    public string objectName;
    public int keyType;

    private RaycastHit2D hit;
    private Collider2D HitCollider;

    private void FixedUpdate()
    {
        // 创建一条射线，从物体的位置向下发射
        Vector2 rayDirection = Vector2.down;
        hit = Physics2D.Raycast(transform.position, rayDirection, Mathf.Infinity, hitLayer);

        if (hit)
        {
            HitCollider = hit.collider;
            string hitObjectName = HitCollider.gameObject.name;

            if (hitObjectName == objectName)
            {
                switch (keyType)
                {
                    case 1:
                        Debug.Log("Key1 hit.");
                        Static.iskey1ed = true;
                        break;
                    case 2:
                        Debug.Log("Key2 hit.");
                        Static.iskey2ed = true;
                        break;
                    case 3:
                        Debug.Log("Key3 hit.");
                        Static.iskey3ed = true;
                        break;
                }
                Destroy(gameObject);
            }
            else
            {
                if (keyType == 1)
                {
                    Static.iskey1ed = false;
                }
                else if (keyType == 2)
                {
                    Static.iskey2ed = false;
                }
                else if (keyType == 3)
                {
                    Static.iskey3ed = false;
                }
            }
        }
    }
}
