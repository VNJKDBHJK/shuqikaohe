using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhazhiPicChange : MonoBehaviour
{
    public Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
            if (Static.isOpenInZhazhi)
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
