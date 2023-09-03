using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumManager : MonoBehaviour
{
    private void OnEnable()
    {
        NumberController.OnLockOpen += OnLockOpened;
        NumberController.OnLockClose += OnLockClosed;
    }

    private void OnDisable()
    {
        NumberController.OnLockOpen -= OnLockOpened;
        NumberController.OnLockClose -= OnLockClosed;
    }

    private void OnLockOpened()
    {
        Static.isdone = true;
    }

    private void OnLockClosed()
    {
        Static.isdone = false;
    }

}
