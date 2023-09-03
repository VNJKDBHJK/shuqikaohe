using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInZhazhiOnClick1 : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject paw;
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
        if (Static.paw == 1)
        {
            audioSource.PlayOneShot(click);
            GameObject newObj = Instantiate(paw, new Vector3(-2.11f, 4.53f, 0), Quaternion.Euler(0, 0, 0));
            Static.paw++;
        }
    }
    private void OnMouseUp()
    {
        sr.enabled = false;
    }
}
