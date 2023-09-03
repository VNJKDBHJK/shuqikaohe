using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicLarge6 : MonoBehaviour
{
    private void Update()
    {
        if (Static.isPic6)
            SetScale(new Vector3(1.6f, 1.6f, 1f));
    }

    private void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}
