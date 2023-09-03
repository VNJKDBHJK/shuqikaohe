using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public GameObject minute;
    public GameObject Hour;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
            if (minute.transform.localEulerAngles.z == 330f && Hour.transform.localEulerAngles.z==90f&&Static.isclock1==1)
        {
            //Event1
            Static.isopen1 = true;
            GameObject newObj = Instantiate(prefab1, new Vector3(5, 4f, 0), Quaternion.identity);
            Static.isclock1++;
        }else if(minute.transform.localEulerAngles.z == 150f && Hour.transform.localEulerAngles.z == 270f && Static.isclock2 == 1)
        {
            Static.isopen2 = true;
            GameObject newObj = Instantiate(prefab2, new Vector3(5, -1.12f, 0), Quaternion.identity);
            Static.isclock2++;
        }else if(minute.transform.localEulerAngles.z == 180f && Hour.transform.localEulerAngles.z >= 28f&& Hour.transform.localEulerAngles.z<=33f && Static.isclock3 == 1)
        {
            Static.isopen3 = true;
            GameObject newObj = Instantiate(prefab3, new Vector3(5, -6.68f, 0), Quaternion.identity);
            Static.isclock3++;
        }

    }
}
