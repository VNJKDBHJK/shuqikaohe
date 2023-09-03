using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movecase0102R : MonoBehaviour
{
    public AnimationCurve curve;
    public float speed;
    public Vector3 moveDir;

    public AnimationCurve curve1;
    public float speed1;
    public Vector3 moveDir1;

    private int id;
    Vector3 originPos;

    public bool iskey1;
    public bool iskey2;
    public bool iskey3;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public bool islock1;
    public bool islock2;
    public bool islock3;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public bool is1;
    public bool is2;
    public bool is3;

    private AudioSource audioSource;
    public AudioClip Lock;
    public AudioClip Drag;
    public AudioClip pop;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        id = GetComponent<DrawerOnDragg>().ID;
        originPos = transform.position;
    }

    private void Update()
    {
        Collider2D clickedCollider = GetClickedCollider();
        if (clickedCollider != null)
        {
            if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("item"))
            {
                if (clickedCollider.gameObject.name == "Key1(Clone)")
                {
                    GameObject newObj = Instantiate(prefab1, new Vector3(-9.49f, 2.01f, 0), Quaternion.identity);
                    Destroy(GameObject.Find("Key1(Clone)"));
                    Static.iskey1ed = true;
                    islock1 = false;

                    audioSource.PlayOneShot(Lock);
                }

                if (clickedCollider.gameObject.name == "Key2(Clone)")
                {
                    GameObject newObj = Instantiate(prefab2, new Vector3(-3.47f, 2.26f, 0), Quaternion.identity);
                    Destroy(GameObject.Find("Key2(Clone)"));
                    Static.iskey2ed = true;
                    islock2 = false;

                    audioSource.PlayOneShot(pop);
                }

                if (clickedCollider.gameObject.name == "Key3(Clone)")
                {
                    GameObject newObj = Instantiate(prefab3, new Vector3(-9.49f, 1.8f, 0), Quaternion.identity);
                    Destroy(GameObject.Find("Key3(Clone)"));
                    Static.iskey3ed = true;
                    islock3 = false;

                    audioSource.PlayOneShot(Lock);
                }
            }
        }

        if (Static.iskey1ed)
            islock1 = false;

        if (Static.iskey2ed)
            islock2 = false;

        if (Static.iskey3ed)
            islock3 = false;
    }
    private void OnMouseDown()
    {
        if (!Static.isPause)
        {
            if (is1)
                if (!islock1)
                {
                    StartCoroutine(Move());
                    text1.text = "";
                }
                else
                {
                    text1.text = "lock";
                    Static.movecasenumber2[id] = 1;
                    audioSource.PlayOneShot(Lock);
                }

            if (is2)
                if (!islock2)
                {
                    StartCoroutine(Move());
                    text2.text = "";
                }
                else
                {
                    text2.text = "lock";
                    Static.movecasenumber2[id] = 1;
                    audioSource.PlayOneShot(Lock);
                }

            if (is3)
                if (!islock3)
                {
                    StartCoroutine(Move());
                    text3.text = "";
                }
                else
                {
                    text3.text = "lock";
                    Static.movecasenumber2[id] = 1;
                    audioSource.PlayOneShot(Lock);
                }
        }
    }

    IEnumerator Move()
    {
        audioSource.PlayOneShot(Drag);

        float percent = 0;
        float movetime = 2f; // 在2秒之内从0移动到1
        if (Static.movecasenumber2[id] % 2 == 0)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed * moveDir * curve.Evaluate(percent);
                
                
                yield return null;
            }
        }

        if (Static.movecasenumber2[id] % 2 == 1)
        {
            while (percent < 1)
            {
                percent += Time.deltaTime / movetime;
                transform.position = originPos + speed1 * moveDir1 * curve1.Evaluate(percent);
                
                yield return null;
            }
        }
    }

    private Collider2D GetClickedCollider()
    {
        // 发射一条射线，并获取点击的碰撞体
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // 检查点击的对象是否有碰撞体
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // 如果有碰撞体，则返回
                return clickedCollider;
            }
        }
        return null;
    }
}
