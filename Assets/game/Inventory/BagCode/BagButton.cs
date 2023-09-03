using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BagButton : MonoBehaviour
{
    public int BBID;//空格/物品的ID
    public item BBItem;
    public Image BBImage;
    public TMP_Text BBNum;
    public string BBInfo;

    public GameObject ItemInBB;

    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(BBInfo);
    }

    public void SetUpBB(item item)
    {
        if (item == null)
        {
            ItemInBB.SetActive(false);
            return;
        }
        BBItem = item;
        BBImage.sprite = item.itemImage;
        BBNum.text = item.itemHeld.ToString();
        BBInfo = item.itemInfo;
        transform.GetComponentInChildren<ItemOnDrag>().myItem = item;
    }
}
