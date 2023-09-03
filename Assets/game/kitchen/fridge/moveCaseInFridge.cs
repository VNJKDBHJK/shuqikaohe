using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCaseInFridge : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    public AnimationCurve curve1;
    public float speed1;
    public Vector3 moveDir1;

    Vector3 originPos;
    private Vector3 iceOriginPos;
    public GameObject ice;

    private AudioSource audioSource;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originPos = transform.position;
        iceOriginPos = new Vector3(-3.02f, -6.01f, 0);
    }

    // Update is called once per frame
    void Update()
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
        if (Static.moveInFridge % 2 == 0)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed * moveDir * curve.Evaluate(percent);
                if (Static.iceOne == 1)
                {
                    GameObject newObj = Instantiate(ice, iceOriginPos + speed * moveDir * curve.Evaluate(percent), Quaternion.identity);
                    Static.iceOne++;
                }
                yield return null;
            }
        }

        if (Static.moveInFridge % 2 == 1)
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
