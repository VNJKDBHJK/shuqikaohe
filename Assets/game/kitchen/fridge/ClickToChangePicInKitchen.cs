using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChangePicInKitchen : MonoBehaviour
{
    public Sprite[] images;

    public GameObject GaiZi;
    public GameObject ChouTi;
    private int ClickNum=0;

    public GameObject EmptyCup;
    public GameObject crutch;
    private AudioSource audioSource;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GaiZi.SetActive(false);
        ChouTi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            audioSource.PlayOneShot(click);
            ClickNum++;
            if (ClickNum % 2 == 1)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[1];
                GaiZi.SetActive(true);
                ChouTi.SetActive(true);
                if (Static.EmptyCup == 1)
                {
                    GameObject newObj = Instantiate(EmptyCup, new Vector3(-2.25f, 1.76f, 0), Quaternion.identity);
                    Static.EmptyCup++;
                }
                if (Static.crutch == 1)
                {
                    GameObject newObj = Instantiate(crutch, new Vector3(-6.87f, -2.32f, 0), Quaternion.Euler(0, 0, -58.93f));
                    Static.crutch++;
                }
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
                GaiZi.SetActive(false);
                ChouTi.SetActive(false);
            }
        }
    }
}
