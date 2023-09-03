using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;
    private int currentID;//��ǰ��Ʒ��id
    public Inventory mybag;

    public item myItem;
    public Image BBImage;
    public TMP_Text BBNum;
    public string BBInfo;
    public GameObject ItemInBB;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;//��¼ԭ������
        currentID = originalParent.GetComponent<BagButton>().BBID;
        transform.SetParent(transform.parent.parent);//���븸����
        transform.position = eventData.position;//����λ��=���λ��
        GetComponent<CanvasGroup>().blocksRaycasts = false;//ȡ��CanvasGroup��ѡ
    }

    public void OnDrag(PointerEventData eventData)
    {
/*        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);//��ʾ����·����ߴ򵽵���Ʒ����*/
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

                //������ƷID�ĶԵ�
                var temp = mybag.itemList[currentID];
                mybag.itemList[currentID] = mybag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<BagButton>().BBID];//Ŀ����Ʒ��id��ԭ�����id���е���
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

                //����Ʒ������Ϊ��ʱ
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
                    //ˢ�±���
                    InventoryManager.RefreshItem();

                    Vector3 mousePosition = Input.mousePosition; // ��ȡ���λ��

                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition); // ����Ļ����ת��Ϊ��������
                    spawnPosition.z = -10f;
                    GameObject spawnedObject = Instantiate(myItem.prefeb, spawnPosition, Quaternion.identity);
                }
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
            //����λ��
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
}
