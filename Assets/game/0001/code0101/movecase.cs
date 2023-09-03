using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecase : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    Vector3 originPos;

    public AudioClip move;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originPos = transform.position;
    }

    private void OnMouseDown()
    {
        if(!Static.isPause)
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        audioSource.PlayOneShot(move);
        float percent = 0;
        float movetime = 2f;//在2秒之内从0移动到1
        while (percent < 1)
        {
            percent += Time.deltaTime / movetime;
            transform.position = originPos + speed * moveDir*curve.Evaluate(percent);

            yield return null;//一帧一帧执行而不是一帧执行完全部 关于协程->https://blog.csdn.net/beihuanlihe130/article/details/76098844
        }
    }
}
