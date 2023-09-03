using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesofa : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    Vector3 originPos;
    public GameObject redkey;

    private AudioSource audioSource;
    public AudioClip click;
    public AudioClip keySound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            StartCoroutine(Move());
            if (Static.redkeyOne == 1)
            {
                audioSource.PlayOneShot(keySound);
                GameObject newObj = Instantiate(redkey, new Vector3(-2.34f, -3.05f, 0), Quaternion.identity);
                Static.redkeyOne++;
            }
            else
            {
                audioSource.PlayOneShot(click);
            }
        }
    }

    IEnumerator Move()
    {
        float percent = 0;
        float movetime = 2f;//在2秒之内从0移动到1
        while (percent < 1)
        {
            percent += Time.deltaTime / movetime;
            transform.position = originPos + speed * moveDir * curve.Evaluate(percent);

            yield return null;
        }
    }
}
