using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minu : MonoBehaviour
{
    public float a;

    private AudioSource audioSource;
    public AudioClip click;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            a -= 30f;
        }
        if (a >= 360f) a -= 360f;
        if (a <= -360f) a += 360f;
    }
    public void MinuOnClick()
    {
        if (!Static.isPause)
        {
            audioSource.PlayOneShot(click);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, a);
        }
    }
}
