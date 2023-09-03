using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject mybag;
    bool isopen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenMyBag();
    }

    void OpenMyBag()
    {
        if(!Static.isPause)
        if (Input.GetKeyDown(KeyCode.L))
        {
            isopen = !isopen;
            mybag.SetActive(isopen);
        }
    }
}
