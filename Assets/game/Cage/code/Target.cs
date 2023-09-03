using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public string SceneName;
    public string Tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            // ��ȡ��ǰ����ĳ���
            Scene currentScene = SceneManager.GetActiveScene();
            // ��ȡ����������
            string sceneName = currentScene.name;
            if (sceneName != SceneName)
            {
                string targetTag = Tag;
                GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
                foreach (GameObject obj in targetObjects)
                {
                    // ��������
                    Destroy(obj);
                }
            }
        } 
    }
}
