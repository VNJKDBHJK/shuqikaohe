using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCanvasControler : MonoBehaviour
{

    public GameObject button;
    private static SecondCanvasControler instance;

    public static SecondCanvasControler Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    private void Start()
    {
        if (NumberController.Instance == null)
        {
            Debug.LogError("Failed to get NumberController component!");
        }
    }

    private void Update()
    {
        Debug.Log(Static.isdone);
    }
}
