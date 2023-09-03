using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    public Color finishColor;
    Color StartColor;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    private AudioSource audioSource;
    public AudioClip click;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartColor = GetComponent<SpriteRenderer>().color;

       
    }

    private void Update()
    {
        // 获取当前激活的场景
        Scene currentScene = SceneManager.GetActiveScene();
        // 获取场景的名称
        string sceneName = currentScene.name;
        Debug.Log(sceneName);
        if (sceneName != "Cage")
        {
            string targetTag = "BOX";
            GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject obj in targetObjects)
            {
                // 销毁物体
                Destroy(obj);
            }
        }
    }

    public bool CanMoveToDir(Vector2 dir)
    {
        if (!Static.isPause)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + 0.5f * (Vector3)dir, dir, 0.5f);

            if (!hit)
            {
                transform.Translate(dir);
                return true;
            }

        }
            return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Static.isPause)
        {
            if (collision.CompareTag("Tag"))
            {
                GetComponent<SpriteRenderer>().color = finishColor;
                //Event1
                if (Static.is1 == 1)
                {
                    audioSource.PlayOneShot(click);
                    GameObject newObj = Instantiate(prefab1, new Vector3(-5, -4, 0), Quaternion.identity);
                    Static.is1++;
                }
            }
            if (collision.CompareTag("Tag1"))
            {
                GetComponent<SpriteRenderer>().color = finishColor;
                //Event2
                if (Static.is2 == 1)
                {
                    audioSource.PlayOneShot(click);
                    GameObject newObj = Instantiate(prefab2, new Vector3(8, -4, 0), Quaternion.identity);
                    Static.is2++;
                }
            }
            if (collision.CompareTag("Tag2"))
            {
                GetComponent<SpriteRenderer>().color = finishColor;
                //Event3
                if (Static.is3 == 1)
                {
                    audioSource.PlayOneShot(click);
                    GameObject newObj = Instantiate(prefab3, new Vector3(6, 3, 0), Quaternion.identity);
                    Static.is3++;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Static.isPause)
        {
            if (collision.CompareTag("Tag"))
            {
                GetComponent<SpriteRenderer>().color = StartColor;
            }
        }
    }

}
