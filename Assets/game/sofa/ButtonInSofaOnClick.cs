using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInSofaOnClick : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject Pic6;

    private AudioSource audioSource;
    public AudioClip click;
    public AudioClip Otherclick;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            sr.enabled = true;
            if (Static.Pic6 == 1)
            {
                audioSource.PlayOneShot(click);
                GameObject newObj = Instantiate(Pic6, new Vector3(-12.5f, -1.4f, 0), Quaternion.Euler(0, 0, 0));
                Static.Pic6++;
            }
            else
            {
                audioSource.PlayOneShot(Otherclick);
            }
        }
    }
    private void OnMouseUp()
    {
        if (!Static.isPause)
            sr.enabled = false;
    }
}
