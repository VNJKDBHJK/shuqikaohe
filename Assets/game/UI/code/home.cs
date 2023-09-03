using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public void ReloadScenes()//重新加载所有场景
    {
        int sceneCount = SceneManager.sceneCount;//当前加载的场景总数

        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);//获取加载场景
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        }
    }

    public void HomeOnClick()
    {
        ReloadScenes();
        SceneManager.LoadScene(0000);
    }
}
