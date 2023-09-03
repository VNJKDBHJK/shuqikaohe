using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround;
    public LayerMask layerMask;

    void Update()
    {
        var raycastAll = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.4f, 0.4f), 0, layerMask);
        if (raycastAll.Length > 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector2(0.4f, 0.4f));
    }
}
