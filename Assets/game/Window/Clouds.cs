using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    Vector3 originPos;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    private void OnMouseDown()
    {
        StartCoroutine(Move());
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
