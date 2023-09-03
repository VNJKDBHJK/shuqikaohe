using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOnClick : MonoBehaviour
{
    public Sprite[] images;
    private int numb = 0;
    public GameObject flower;

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
        
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            numb++;
            audioSource.PlayOneShot(click);
            if (numb % 2 == 1)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[1];
                if (Static.flower == 1)
                {
                    GameObject newObj = Instantiate(flower, new Vector3(-6.7f, -2.4f, 0), Quaternion.Euler(0, 0, 90));
                    Static.flower++;
                }
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
            }
        }
    }
}
