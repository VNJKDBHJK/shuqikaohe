using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkNPC : MonoBehaviour
{
    public bool istalk;
    public Sprite[] images;
    public TMP_Text text;
    public AudioSource audioSource;

    public GameObject one;
    public GameObject hat;
    public AudioClip mp3File;

    public GameObject two;
    public GameObject tie;
    public AudioClip mp3File1;

    public GameObject three;
    public GameObject crutch;
    public AudioClip mp3File2;

    public AudioClip click;
    private void Start()
    {
        hat.SetActive(false);
        tie.SetActive(false);
        crutch.SetActive(false);
        StartCoroutine(ResetTalk());
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!Static.isPause)
            if (Static.isopenWindow)
            {
            TALK();

            //COLLIDER
            Collider();

            //Event
            Event();
            }
    }

    private void TALK()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        istalk = true;
                        if (!Static.finishOne)
                        {
                            PlayAudio1();
                            text.text = "Hello, if you can give me a hat, I will give you what you want .";
                        }
                        else if (!Static.finishTwo)
                        {
                            PlayAudio2();
                            text.text = "Thank you, and do you have a tie ?";
                        }
                        else if (!Static.finishTree)
                        {
                            PlayAudio3();
                            text.text = "Then give me that crutch !";
                        }
                        else
                        {
                            text.text = " ";
                        }
                        StopCoroutine(ResetTalk());  // 停止协程
                        StartCoroutine(ResetTalk()); // 重新开始协程
                    }
                }
            }
            if (istalk)
            {
                spriteRenderer.sprite = images[1];
            }
            else
            {
                spriteRenderer.sprite = images[0];
            }
        if (Static.finishOne && Static.finishTwo && Static.finishTree)
        {
            text.text = " ";
            istalk = false;
            Static.isfinish = true;
        }
    }

    private void Collider()
    {
        Collider2D clickedCollider = GetClickedCollider();
        if (clickedCollider != null)
        {
            if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("item"))
            {
                if (clickedCollider.gameObject.name == "HAT(Clone)")
                {
                    Static.finishOne = true;
                    Destroy(GameObject.Find("HAT(Clone)"));
                }else if (clickedCollider.gameObject.name == "tie(Clone)")
                {
                    Static.finishTwo = true;
                    Destroy(GameObject.Find("tie(Clone)"));
                }else if (clickedCollider.gameObject.name == "crutch(Clone)")
                {
                    Static.finishTree = true;
                    Destroy(GameObject.Find("crutch(Clone)"));
                }
            }
        }
    }

    private void Event()
    {
        if (Static.finishOne)
        {
            hat.SetActive(true);

            if (Static.finishOneNum == 1)
            {
                audioSource.PlayOneShot(click);
                GameObject newObj = Instantiate(one, new Vector3(4.351193f, 1.627155f, 0), Quaternion.identity);
            Static.finishOneNum++;
            }
        }

        if (Static.finishTwo)
        {
            tie.SetActive(true);

            if(Static.finishTwoNum == 1)
            {
                audioSource.PlayOneShot(click);
                GameObject newObj = Instantiate(two, new Vector3(4.351193f, 1.627155f, 0), Quaternion.identity);
            Static.finishTwoNum++;
            }
        }

        if (Static.finishTree)
        {
            crutch.SetActive(true);

            if(Static.finishTreeNum == 1)
            {
                audioSource.PlayOneShot(click);
                GameObject newObj = Instantiate(three, new Vector3(4.351193f, 1.627155f, 0), Quaternion.identity);
            Static.finishTreeNum++;
            }
        }
    }
    public void PlayAudio1()
    {
        if(!Static.isPause)
        if (audioSource != null && mp3File != null)
        {
            audioSource.clip = mp3File;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }

    public void PlayAudio2()
    {
        if (!Static.isPause)
        if (audioSource != null && mp3File1 != null)
        {
            audioSource.clip = mp3File1;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }

    public void PlayAudio3()
    {
        if (!Static.isPause)
        if (audioSource != null && mp3File2 != null)
        {
            audioSource.clip = mp3File2;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }

    IEnumerator ResetTalk()
    {
        yield return new WaitForSeconds(7f);
        istalk = false;
    }

    private Collider2D GetClickedCollider()
    {
        // 发射一条射线，并获取点击的碰撞体
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // 检查点击的对象是否有碰撞体
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // 如果有碰撞体，则返回
                return clickedCollider;
            }
        }
        return null;
    }
}
