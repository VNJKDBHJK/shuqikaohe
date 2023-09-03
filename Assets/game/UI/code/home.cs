using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public void ReloadScenes()//���¼������г���
    {
        int sceneCount = SceneManager.sceneCount;//��ǰ���صĳ�������

        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);//��ȡ���س���
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        }
    }

    public void HomeOnClick()
    {
        ReloadScenes();
        SceneManager.LoadScene(0000);
    }
}
