using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOnClick : MonoBehaviour
{
    public Sprite[] images;

    public int id;
    public bool isL1;
    public bool isO;
    public bool isS1;
    public bool isT;
    public bool isI;
    public bool isS2;
    public bool isL2;
    public bool isA;
    public bool isN;
    public bool isD;

    private AudioSource audioSource;
    public AudioClip click;
    public AudioClip click2;
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
            Static.bookId[id]++;
            if (!Static.istrue)
            {
                if (Static.bookId[id] % 2 == 1)
                {
                    audioSource.PlayOneShot(click);
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[1];
                    if (isL1)
                    {
                        Static.bookisRight[0] = true;
                    }
                    else if (isO)
                    {
                        Static.bookisRight[1] = true;
                    }
                    else if (isS1)
                    {
                        Static.bookisRight[2] = true;
                    }
                    else if (isT)
                    {
                        Static.bookisRight[3] = true;
                    }
                    else if (isI)
                    {
                        Static.bookisRight[4] = true;
                    }
                    else if (isS2)
                    {
                        Static.bookisRight[5] = true;
                    }
                    else if (isL2)
                    {
                        Static.bookisRight[6] = true;
                    }
                    else if (isA)
                    {
                        Static.bookisRight[7] = true;
                    }
                    else if (isN)
                    {
                        Static.bookisRight[8] = true;
                    }
                    else if (isD)
                    {
                        Static.bookisRight[9] = true;
                    }
                    else
                    {
                        Static.isright[id] = true;
                    }

                }
                else
                {
                    audioSource.PlayOneShot(click2);
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[0];
                    if (isL1)
                    {
                        Static.bookisRight[0] = false;
                    }
                    else if (isO)
                    {
                        Static.bookisRight[1] = false;
                    }
                    else if (isS1)
                    {
                        Static.bookisRight[2] = false;
                    }
                    else if (isT)
                    {
                        Static.bookisRight[3] = false;
                    }
                    else if (isI)
                    {
                        Static.bookisRight[4] = false;
                    }
                    else if (isS2)
                    {
                        Static.bookisRight[5] = false;
                    }
                    else if (isL2)
                    {
                        Static.bookisRight[6] = false;
                    }
                    else if (isA)
                    {
                        Static.bookisRight[7] = false;
                    }
                    else if (isN)
                    {
                        Static.bookisRight[8] = false;
                    }
                    else if (isD)
                    {
                        Static.bookisRight[9] = false;
                    }
                    else
                    {
                        Static.isright[id] = false;
                    }
                }
            }
            else
            {
                if (isL1 || isO || isS1 || isS2 || isT || isI || isL2 || isA || isN || isD)
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
}
