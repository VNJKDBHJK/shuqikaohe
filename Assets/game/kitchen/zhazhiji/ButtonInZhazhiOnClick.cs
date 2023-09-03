using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInZhazhiOnClick : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject yijia;
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
        if (!Static.isPause)
        {
            sr.enabled = true;
            if (Static.yijia == 1)
            {
                audioSource.PlayOneShot(click);
                GameObject newObj = Instantiate(yijia, new Vector3(-7.57f, 1.77f, 0), Quaternion.Euler(0, 0, 0));
                Static.yijia++;
            }
        }
    }
    private void OnMouseUp()
    {
        if (!Static.isPause)
            sr.enabled = false;
    }
}
