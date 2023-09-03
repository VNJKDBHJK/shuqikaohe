using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPicture : MonoBehaviour
{
    private RaycastHit hit;
    GameObject hitObject;
    string hitObjectName;
    public string ObjectName;
    public string SceneName;

    private void Update()
    {
        // 创建一条射线，从物体的位置向下发射
        Ray ray = new Ray(transform.position, Vector3.down);
        // 进行射线检测
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, 0, 1), 1000, 1);
        if (hit)
        {
            hitObject = hit.collider.gameObject;
            hitObjectName = hitObject.name;
/*            Debug.Log(hitObjectName);*/
            if (hitObjectName == ObjectName)
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }

    /*public string SceneName;
    private GameObject ColliderObject;
    public string ObjectName;

    private string objectName;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            ColliderObject = hit.collider.gameObject;
            objectName = ColliderObject.name;
        }
        Debug.Log(objectName);
        if (ObjectName == objectName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }*/
}
