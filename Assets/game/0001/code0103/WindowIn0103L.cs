using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowIn0103L : MonoBehaviour
{
    public Sprite[] images;
    public AudioClip Click;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Static.iscanvas2)
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = images[1];
            audioSource.PlayOneShot(Click);
        }
        else
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = images[0];
        }
    }
}
