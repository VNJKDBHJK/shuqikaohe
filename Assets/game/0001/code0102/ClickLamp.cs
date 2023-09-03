using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLamp : MonoBehaviour
{
    public GameObject pic1;
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
            if (Static.Pic1 == 1)
            {
                audioSource.PlayOneShot(click);
                GameObject newObj = Instantiate(pic1, new Vector3(-3.94f, -5.75f, 0), Quaternion.Euler(0, 0, 0));
                Static.Pic1++;
            }
    }
}
