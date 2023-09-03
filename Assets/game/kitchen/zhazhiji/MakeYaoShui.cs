using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeYaoShui : MonoBehaviour
{
    public GameObject BluePotion;
    public GameObject GreenPotion;
    public GameObject RedPotion;

    public AudioClip Click;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            if (Static.is101 && Static.is102 && Static.is103 && Static.is104 && Static.is1001 == 1)
            {
                audioSource.PlayOneShot(Click);
                Static.is1001++;
                GameObject newObj = Instantiate(BluePotion, new Vector3(2.03f, -3.06f, 0), Quaternion.identity);
                hasTriggeredAudio = true;
            }

            if (Static.is201 && Static.is202 && Static.is203 && Static.is204 && Static.is2001 == 1)
            {
                audioSource.PlayOneShot(Click);
                Static.is2001++;
                GameObject newObj = Instantiate(GreenPotion, new Vector3(2.03f, -5.4f, 0), Quaternion.identity);
                hasTriggeredAudio = true;
                Static.isC2 = true;
            }

            if (Static.is301 && Static.is302 && Static.is303 && Static.is304 && Static.is3001 == 1)
            {
                audioSource.PlayOneShot(Click);
                Static.is3001++;
                GameObject newObj = Instantiate(RedPotion, new Vector3(2.03f, -7.7f, 0), Quaternion.identity);
                hasTriggeredAudio = true;
            }
        }
    }
}
