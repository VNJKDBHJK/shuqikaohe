using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movedawerL : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    public AnimationCurve curve1;
    public float speed1;
    public Vector3 moveDir1;

    Vector3 originPos;
    public GameObject prefab;
    public bool islock;
    public TMP_Text text;

    private AudioSource audioSource;
    public AudioClip Unlock;
    public AudioClip Lock;
    public AudioClip clickSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originPos = transform.position;
    }

    private void Update()
    {
        Debug.Log(islock);
        if (Static.iscall1)
            islock = false;
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
            if (!islock)
            {
                StartCoroutine(Move());
                text.text = "";
            audioSource.PlayOneShot(Lock);
            }
            else
            {
                text.text = "Please proceed first";
            audioSource.PlayOneShot(Unlock);
            }
    }

    IEnumerator Move()
    {
        audioSource.PlayOneShot(clickSound);
        float percent = 0;
        float movetime = 2f; // 在2秒之内从0移动到1
        if (Static.movecaseNumber % 2 == 0)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed * moveDir * curve.Evaluate(percent);

                if (Static.iscall1 && Static.iscall01 == 1)
                {
                    GameObject newObj = Instantiate(prefab, new Vector3(-3, -2f, 0), Quaternion.identity);
                    Static.iscall01++;
                }
                yield return null;
            }
        }

        if (Static.movecaseNumber % 2 == 1)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed1 * moveDir1 * curve1.Evaluate(percent);

                yield return null;
            }
        }
    }
}
