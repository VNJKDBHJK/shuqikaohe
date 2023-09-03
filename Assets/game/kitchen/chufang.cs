using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chufang : MonoBehaviour
{
    public Sprite[] images;
    private int clickNum=0;

    public GameObject rag;
    private AudioSource audioSource;
    public AudioClip click;
    public AudioClip clickclose;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = images[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            clickNum++;
            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
            {
                if (clickNum % 2 == 1)
                {
                    audioSource.PlayOneShot(click);
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[1];
                    if (Static.rag == 1)
                    {
                        GameObject newObj = Instantiate(rag, new Vector3(-14.62f, -4.2f, 0), Quaternion.identity);
                        Static.rag++;
                    }
                }
                else
                {
                    audioSource.PlayOneShot(clickclose);
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[0];
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
