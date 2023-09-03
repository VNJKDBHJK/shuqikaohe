using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCaseK : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    public AnimationCurve curve1;
    public float speed1;
    public Vector3 moveDir1;

    Vector3 originPos;
    public GameObject knife;
    private AudioSource audioSource;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originPos = transform.position;
    }

    private void Update()
    {
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            audioSource.PlayOneShot(click);
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        float percent = 0;
        float movetime = 2f; // 在2秒之内从0移动到1
        if (Static.kitchen% 2 == 0)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed * moveDir * curve.Evaluate(percent);

                yield return null;
            }
        }

        if (Static.kitchen % 2 == 1)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed1 * moveDir1 * curve1.Evaluate(percent);

                yield return null;
            }
            if (Static.knife == 1)
            {
                GameObject newObj = Instantiate(knife, new Vector3(-3.95f, -2.38f, 0), Quaternion.Euler(0, 0, 90));
                Static.knife++;
            }
        }
    }
}
