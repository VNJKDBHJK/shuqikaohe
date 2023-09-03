using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pic1 : MonoBehaviour
{
    public string GameObjectTag;
    public bool isPic1;
    public bool isPic2;
    public bool isPic3;
    public bool isPic4;
    public bool isPic5;
    public bool isPic6;

    public Vector3 Pic1Position;
    public Vector3 Pic2Position;
    public Vector3 Pic3Position;
    public Vector3 Pic4Position;
    public Vector3 Pic5Position;
    public Vector3 Pic6Position;

    public GameObject gameobject;

    public AudioClip Click;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        gameobject = gameObject;

        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;
    }

    private void Update()
    {
        if (!Static.isPause)
        {
            Collider2D clickedCollider = GetClickedCollider();
            // 获取当前激活的场景
            Scene currentScene = SceneManager.GetActiveScene();
            // 获取场景的名称
            string sceneName = currentScene.name;
            if (gameobject != null)
            {
                if (sceneName == "PictureToPick")
                {
                    if (isPic1)
                        if (Static.ispicture1)
                            gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                    if (isPic2)
                        if (Static.ispicture2)
                            gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                    if (isPic3)
                        if (Static.ispicture3)
                            gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                    if (isPic4)
                        if (Static.ispicture4)
                            gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                    if (isPic5)
                        if (Static.ispicture5)
                            gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                    if (isPic6)
                        if (Static.ispicture6)
                            gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                }
                else
                {
                    Debug.Log(123);
                    gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                }
            }
            else
            {
                string targetTag = "PIC";
                GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
                foreach (GameObject obj in targetObjects)
                {
                    // 销毁物体
                    Destroy(obj);
                }
            }

            if (clickedCollider != null)
            {
                if (clickedCollider.gameObject.tag == GameObjectTag)
                {
                    if (isPic1)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isPic1 = true;
                        Transform clickedTransform = clickedCollider.transform;
                        // 将物体移动到指定位置
                        clickedTransform.position = Pic1Position;
                        BoxCollider2D boxCollider = clickedCollider.GetComponent<BoxCollider2D>();
                        if (boxCollider != null)
                        {
                            boxCollider.enabled = false;
                        }

                        Static.ispicture1 = true;
                        hasTriggeredAudio = true;
                    }

                    if (isPic2)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isPic2 = true;
                        Transform clickedTransform = clickedCollider.transform;
                        // 将物体移动到指定位置
                        clickedTransform.position = Pic2Position;
                        BoxCollider2D boxCollider = clickedCollider.GetComponent<BoxCollider2D>();
                        if (boxCollider != null)
                        {
                            boxCollider.enabled = false;
                        }
                        Static.ispicture2 = true;
                        hasTriggeredAudio = true;
                    }

                    if (isPic3)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isPic3 = true;
                        Transform clickedTransform = clickedCollider.transform;
                        // 将物体移动到指定位置
                        clickedTransform.position = Pic3Position;
                        BoxCollider2D boxCollider = clickedCollider.GetComponent<BoxCollider2D>();
                        if (boxCollider != null)
                        {
                            boxCollider.enabled = false;
                        }
                        Static.ispicture3 = true;
                        hasTriggeredAudio = true;
                    }

                    if (isPic4)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isPic4 = true;
                        Transform clickedTransform = clickedCollider.transform;
                        // 将物体移动到指定位置
                        clickedTransform.position = Pic4Position;
                        BoxCollider2D boxCollider = clickedCollider.GetComponent<BoxCollider2D>();
                        if (boxCollider != null)
                        {
                            boxCollider.enabled = false;
                        }
                        Static.ispicture4 = true;
                        hasTriggeredAudio = true;
                    }

                    if (isPic5)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isPic5 = true;
                        Transform clickedTransform = clickedCollider.transform;
                        // 将物体移动到指定位置
                        clickedTransform.position = Pic5Position;
                        BoxCollider2D boxCollider = clickedCollider.GetComponent<BoxCollider2D>();
                        if (boxCollider != null)
                        {
                            boxCollider.enabled = false;
                        }
                        Static.ispicture5 = true;
                        hasTriggeredAudio = true;
                    }

                    if (isPic6)
                    {
                        audioSource.PlayOneShot(Click);
                        Static.isPic6 = true;
                        Transform clickedTransform = clickedCollider.transform;
                        // 将物体移动到指定位置
                        clickedTransform.position = Pic6Position;
                        BoxCollider2D boxCollider = clickedCollider.GetComponent<BoxCollider2D>();
                        if (boxCollider != null)
                        {
                            boxCollider.enabled = false;
                        }
                        Static.ispicture6 = true;
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
