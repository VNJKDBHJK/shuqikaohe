using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Itrem")]
public class item : ScriptableObject
{
    public string itremName;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public bool equipt;
    public GameObject prefeb;
}
