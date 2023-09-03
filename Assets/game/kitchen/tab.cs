using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tab : MonoBehaviour
{
    public GameObject water;
    public string tabTag;
    public string GameObjectTag;

    public GameObject prefab;

    private int clickNum=0;
    private AudioSource audioSource;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        water.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
                if (clickedCollider.gameObject.tag == GameObjectTag && Static.tabCup == 1)
                {
                    Debug.Log(123);
                    GameObject newObj = Instantiate(prefab, new Vector3(-16.3709f, 2.738818f, 0), Quaternion.identity);
                    Static.tabCup++;
                    Destroy(GameObject.FindWithTag("cup"));
                }
        }
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.tag == tabTag)
                {
                    clickNum++;
                    if (clickNum % 2 == 1)
                    {
                        audioSource.PlayOneShot(click);
                        water.SetActive(true);
                    }
                    else
                    {
                        water.SetActive(false);
                    }
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
