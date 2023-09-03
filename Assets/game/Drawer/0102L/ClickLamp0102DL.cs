using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLamp0102DL : MonoBehaviour
{
    public GameObject fire;

    public AudioClip sound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if(!Static.isPause)
        if (Static.fire == 1)
        {
            audioSource.PlayOneShot(sound);
            GameObject newObj = Instantiate(fire, new Vector3(-10.46f, 1.46f, 0), Quaternion.Euler(0, 0, 0));
            Static.fire++;
        }
    }
}
