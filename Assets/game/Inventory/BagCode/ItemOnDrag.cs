using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;
    private int currentID;//当前物品的id
    public Inventory mybag;

    public item myItem;
    public Image BBImage;
    public TMP_Text BBNum;
    public string BBInfo;
    public GameObject ItemInBB;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;//记录原父物体
        currentID = originalParent.GetComponent<BagButton>().BBID;
        transform.SetParent(transform.parent.parent);//脱离父物体
        transform.position = eventData.position;//物体位置=鼠标位置
        GetComponent<CanvasGroup>().blocksRaycasts = false;//取消CanvasGroup勾选
    }

    public void OnDrag(PointerEventData eventData)
    {
/*        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);//显示鼠标下方射线打到的物品名称*/
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "ItemImage")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                //两个物品ID的对调
                var temp = mybag.itemList[currentID];
                mybag.itemList[currentID] = mybag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<BagButton>().BBID];//目标物品的id与原物体的id进行调换
                mybag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<BagButton>().BBID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if (eventData.pointerCurrentRaycast.gameObject.tag == "BagButton")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                //当物品所处格为空时
                mybag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<BagButton>().BBID] = mybag.itemList[currentID];
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<BagButton>().BBID != currentID)
                    mybag.itemList[currentID] = null;

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if(eventData.pointerCurrentRaycast.gameObject.tag == "use"|| eventData.pointerCurrentRaycast.gameObject.name=="use")
            {
                if(myItem != null)
                {
                    if (myItem.itemHeld <= 1)
                    {
                        mybag.itemList[currentID] = null;
                        myItem.itemHeld = 1;
                    }
                    else
                    {
                        myItem.itemHeld -= 1;
                    }
                    //刷新背包
                    InventoryManager.RefreshItem();

                    Vector3 mousePosition = Input.mousePosition; // 获取鼠标位置

                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition); // 将屏幕坐标转换为世界坐标
                    spawnPosition.z = -10f;
                    GameObject spawnedObject = Instantiate(myItem.prefeb, spawnPosition, Quaternion.identity);
                }
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
            //其他位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
}
