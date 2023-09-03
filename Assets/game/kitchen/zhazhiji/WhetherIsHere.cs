using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhetherIsHere : MonoBehaviour
{
    public GameObject is0101;
    public GameObject is0102;
    public GameObject is0103;
    public GameObject is0104;

    public GameObject is0201;
    public GameObject is0202;
    public GameObject is0203;
    public GameObject is0204;

    public GameObject is0301;
    public GameObject is0302;
    public GameObject is0303;
    public GameObject is0304;

    public AudioClip Click;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;

        is0101.SetActive(false);
        is0102.SetActive(false);
        is0103.SetActive(false);
        is0104.SetActive(false);

        is0201.SetActive(false);
        is0202.SetActive(false);
        is0203.SetActive(false);
        is0204.SetActive(false);

        is0301.SetActive(false);
        is0302.SetActive(false);
        is0303.SetActive(false);
        is0304.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause) { 
            if (Static.is101)
        {
            is0101.SetActive(true);
        }
        if (Static.is102)
        {
            is0102.SetActive(true);
        }
        if (Static.is103)
        {
            is0103.SetActive(true);
        }
        if (Static.is104)
        {
            is0104.SetActive(true);
        }
        if (Static.is201)
        {
            is0201.SetActive(true);
        }
        if (Static.is202)
        {
            is0202.SetActive(true);
        }
        if (Static.is203)
        {
            is0203.SetActive(true);
        }
        if (Static.is204)
        {
            is0204.SetActive(true);
        }
        if (Static.is301)
        {
            is0301.SetActive(true);
        }
        if (Static.is302)
        {
            is0302.SetActive(true);
        }
        if (Static.is303)
        {
            is0303.SetActive(true);
        }
        if (Static.is304)
        {
            is0304.SetActive(true);
        }
        Collider2D clickedCollider = GetClickedCollider();
            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("item"))
                {
                    if (clickedCollider.gameObject.name == "cupWithWater(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is101 = true;
                        is0101.SetActive(true);
                        Destroy(GameObject.Find("cupWithWater(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "ice(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is102 = true;
                        is0102.SetActive(true);
                        Destroy(GameObject.Find("ice(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "appleJuice(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is103 = true;
                        is0103.SetActive(true);
                        Destroy(GameObject.Find("appleJuice(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "pow(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is104 = true;
                        is0104.SetActive(true);
                        Destroy(GameObject.Find("pow(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "FlowerJuice(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is201 = true;
                        is0201.SetActive(true);
                        Destroy(GameObject.Find("FlowerJuice(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "blood(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is202 = true;
                        is0202.SetActive(true);
                        Destroy(GameObject.Find("blood(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "wine(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is203 = true;
                        is0203.SetActive(true);
                        Destroy(GameObject.Find("wine(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "battery(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is204 = true;
                        is0204.SetActive(true);
                        Destroy(GameObject.Find("battery(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "orangeJuice(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is301 = true;
                        is0301.SetActive(true);
                        Destroy(GameObject.Find("orangeJuice(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "medicine(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is302 = true;
                        is0302.SetActive(true);
                        Destroy(GameObject.Find("medicine(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "burnningWood(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is303 = true;
                        is0303.SetActive(true);
                        Destroy(GameObject.Find("burnningWood(Clone)"));
                        hasTriggeredAudio = true;
                    }

                    if (clickedCollider.gameObject.name == "Leyden(Clone)")
                    {
                        audioSource.PlayOneShot(Click);
                        Static.is304 = true;
                        is0304.SetActive(true);
                        Destroy(GameObject.Find("Leyden(Clone)"));
                        Static.Call = true;
                        hasTriggeredAudio = true;
                    }
                }
            }
        }
    }

    private Collider2D GetClickedCollider()
    {
        // 发射一条射线，并获取点击的碰撞体
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        // 检查点击的对象是否有碰撞体
        if (hit.collider != null)
        {
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
