using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableClean : MonoBehaviour
{
    public Sprite[] images;
    public GameObject gameobject;
    // Start is called before the first frame update
    void Start()
    {
        gameobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            if (Static.isclean)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[1];
                gameobject.SetActive(true);
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
                gameobject.SetActive(false);
            }
        }
    }
}
