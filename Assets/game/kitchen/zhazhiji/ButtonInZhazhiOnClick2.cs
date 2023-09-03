using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInZhazhiOnClick2 : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject wine;
    private AudioSource audioSource;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        sr.enabled = true;
        if (Static.wine == 1)
        {
            audioSource.PlayOneShot(click);
            GameObject newObj = Instantiate(wine, new Vector3(4.19f, 2.48f, 0), Quaternion.Euler(0, 0, 0));
            Static.wine++;
        }
    }
    private void OnMouseUp()
    {
        sr.enabled = false;
    }
}
