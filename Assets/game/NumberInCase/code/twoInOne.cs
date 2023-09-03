using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoInOne : MonoBehaviour
{
    public Sprite[] images;
    private int currentIndex = 0;

    private void Start()
    {
    }
    private void Update()
    {
        if (!Static.isPause)
        {
            if (Static.isOpen)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[1];
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
            }
        }
    }
}
