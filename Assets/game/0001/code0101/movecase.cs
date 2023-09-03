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
        float movetime = 2f;//��2��֮�ڴ�0�ƶ���1
        while (percent < 1)
        {
            percent += Time.deltaTime / movetime;
            transform.position = originPos + speed * moveDir*curve.Evaluate(percent);

            yield return null;//һ֡һִ֡�ж�����һִ֡����ȫ�� ����Э��->https://blog.csdn.net/beihuanlihe130/article/details/76098844
        }
    }
}
