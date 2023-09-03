using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePicIn0104W : MonoBehaviour
{
    public Sprite[] images;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
            if (Static.islightened)
            {
               SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[1];
                if (Static.isligtenone == 1)
                {
                    GameObject newObj = Instantiate(prefab, new Vector3(5.91f, -8.59f, 0), Quaternion.identity);
                    Static.isligtenone++;
                }
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
            }
    }
}
