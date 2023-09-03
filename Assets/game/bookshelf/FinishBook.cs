using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class FinishBook : MonoBehaviour
{
    public GameObject Gameobject;
    // Start is called before the first frame update
    void Start()
    {
        Gameobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause)
        {
            bool allTrue = Static.bookisRight.All(b => b);
            bool allFalse = false;
            for (int i = 0; i < Static.isright.Length; i++)
            {
                if (Static.isright[i] == true)
                {
                    allFalse = true;
                }
            }
            if (allTrue && !allFalse)
            {
                Static.istrue = true;
            }
            if (Static.istrue)
            {
                Gameobject.SetActive(true);
            }
        }
       
    }
}
