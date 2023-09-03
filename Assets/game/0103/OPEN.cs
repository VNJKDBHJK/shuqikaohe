using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPEN : MonoBehaviour
{
    public Sprite[] images;
    public GameObject men;

    private AudioSource audioSource;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            if (Static.isfinish)
            {
                men.SetActive(false);
            }
            else
            {
                men.SetActive(true);
            }
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (Static.finishOne)
            {
                spriteRenderer.sprite = images[1];
            }
            else
            {
                spriteRenderer.sprite = images[0];
            }
        }
    }
}
