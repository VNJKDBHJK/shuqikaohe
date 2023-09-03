using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class booktuen : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip click;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();

            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.tag == "Picture")
                {
                    audioSource.PlayOneShot(click);
                    SceneManager.LoadScene("Picture");
                }

                if (clickedCollider.gameObject.tag == "Pictur")
                {
                    audioSource.PlayOneShot(click);
                    SceneManager.LoadScene("Picture1");
                }
                if (clickedCollider.gameObject.tag == "Pictu")
                {
                    audioSource.PlayOneShot(click);
                    SceneManager.LoadScene("Picture2");
                }
            }
        }
    }

    private Collider2D GetClickedCollider()
    {
        // ����һ�����ߣ�����ȡ�������ײ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // ������Ķ����Ƿ�����ײ��
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // �������ײ�壬�򷵻�
                return clickedCollider;
            }
        }
        return null;
    }
}
