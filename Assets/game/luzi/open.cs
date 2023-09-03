using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    private int clickCount = 0;
    public Sprite[] images;

    public GameObject battery;
    private bool istrue;

    private AudioSource audioSource;
    public AudioClip BATTERY;
    public AudioClip Open;
    public AudioClip Close;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null && clickCount % 2 == 1 && Static.haveFire)
            {
                if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("item"))
                {
                    if (clickedCollider.gameObject.name == "Yijia(Clone)" && Static.openisone == 1)
                    {
                        audioSource.clip = BATTERY;
                        audioSource.Play();

                        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = images[2];
                        GameObject newObj = Instantiate(battery, new Vector3(-5.89f, -3.94f, 0), Quaternion.identity);
                        Destroy(GameObject.Find("Yijia(Clone)"));
                        Static.openisone++;
                        istrue = true;
                    }
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (!Static.isPause) { 
            clickCount++;
        Debug.Log("���������" + clickCount);
        audioSource.PlayOneShot(Open);
            if (clickCount % 2 == 0)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
            }
            else
            {
                if (istrue)
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[2];
                }
                else
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[1];
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
