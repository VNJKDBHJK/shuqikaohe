using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOnClick : MonoBehaviour
{
    public string SceneName;
    public string SceneName1;
    public GameObject LOCK;

    public AudioClip move;
    public AudioClip move1;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LOCK.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoorToClick()
    {
        if (!Static.isPause)
        {
            if (Static.isopened) 
            {
                audioSource.PlayOneShot(move1);//ʹ�� PlayOneShot ������һ�� AudioSource �ϲ��Ŷ������
                LOCK.SetActive(false);
                if (Static.CallOnClick && Static.isCanvas1 && Static.isCanvas2)
                {
                    SceneManager.LoadScene(SceneName1);
                }
                else
                {
                    SceneManager.LoadScene(SceneName);
                }
            }
            else
            {
                LOCK.SetActive(true);
                audioSource.PlayOneShot(move);
            }
        }
    }
}
