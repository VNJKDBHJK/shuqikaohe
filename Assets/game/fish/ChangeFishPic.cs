using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFishPic : MonoBehaviour
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
            if (Static.haveknife)
                if (Static.isknife1)
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[1];
                    if (Static.isknife2)
                    {
                        Debug.Log(123);
                        spriteRenderer.sprite = images[2];
                    }
                }
                else
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[0];
                }
    }
}
