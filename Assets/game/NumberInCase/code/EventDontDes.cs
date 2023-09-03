using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDontDes : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
