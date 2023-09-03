using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movecase2 : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    public AnimationCurve curve1;
    public float speed1;
    public Vector3 moveDir1;

    private int id;

    Vector3 originPos;

    public bool isid;
    public GameObject turntoid;

    public bool isTeleScope;
    public GameObject prefab;
    private int isone=0;
    public bool islock;
    public TMP_Text text;

    public bool isphoneNum;
    public GameObject TurnToPhone;

    public bool ishat;
    public GameObject hat;
    public bool istie;
    public GameObject tie;

    public AudioClip clickSound;
    private AudioSource audioSource;
    public AudioClip Unlock;
    public AudioClip Lock;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (isid)
        {
            turntoid.SetActive(false);
        }
        id = GetComponent<DrawerOnDrag>().ID;
        originPos = transform.position;

        if (isphoneNum)
        {
            TurnToPhone.SetActive(false);
        }
    }
    private void Update()
    {
        if (Static.isthree)
            islock = false;
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            if (!islock)
            {
                StartCoroutine(Move());
                text.text = " ";
                PlayClickSoundUnlock();
            }
            else
            {
                text.text = "lock";
                PlayClickSoundLock();
            }

            if (ishat && Static.hat == 1)
            {
                Debug.Log(123);
                GameObject newObj = Instantiate(hat, new Vector3(3.14f, -2.83f, 0), Quaternion.identity);
                Static.hat++;
            }

            if (istie && Static.tie == 1)
            {
                GameObject newObj = Instantiate(tie, new Vector3(2.31f, -8.4f, 0), Quaternion.identity);
                Static.tie++;
            }
        }
    }

    IEnumerator Move()
    {
        PlayClickSound();
        float percent = 0;
        float movetime = 2f; // 在2秒之内从0移动到1
        if (Static.movecasenumber[id] % 2 == 0)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed * moveDir * curve.Evaluate(percent);
                if (isid)
                {
                    turntoid.SetActive(true);
                }
                if (isTeleScope&&isone==0)
                {
                    GameObject newObj = Instantiate(prefab, new Vector3(2, -7f, 0), Quaternion.identity);
                    isone++;
                }

                if (isphoneNum)
                {
                    TurnToPhone.SetActive(true);
                }
                yield return null;
            }
        }

        if (Static.movecasenumber[id] % 2 == 1)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed1 * moveDir1 * curve1.Evaluate(percent);
                if (isid)
                {
                    turntoid.SetActive(false);
                }
                if (isphoneNum)
                {
                    TurnToPhone.SetActive(false);
                }
                yield return null;
            }
        }
    }

    void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
    void PlayClickSoundLock()
    {
        audioSource.PlayOneShot(Lock);
    }
    void PlayClickSoundUnlock()
    {
        audioSource.PlayOneShot(Unlock);
    }
}