using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject BBGrid;
    public GameObject EmptyBB;
    public TMP_Text itemInformation;

    public List<GameObject> BBs = new List<GameObject>();
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;//��Canvas����Ϊ����
    }

    private void OnEnable()
    {
        RefreshItem();
        if(instance!=null)
        instance.itemInformation.text = "";
    }

    //��ÿ����Ʒ��TEXT����
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    //
    public static void RefreshItem()
    {
        if(instance != null)
        {
            for (int i = 0; i < instance.BBGrid.transform.childCount; i++)//i<�������ֵ
            {
                if (instance.transform.childCount == 0)//�ն���
                    break;

                Destroy(instance.BBGrid.transform.GetChild(i).gameObject);//����������
                instance.BBs.Clear();//��ն���
            }

            for (int i = 0; i < instance.myBag.itemList.Count; i++)
            {
                instance.BBs.Add(Instantiate(instance.EmptyBB)); instance.BBs.Add(Instantiate(instance.EmptyBB));
                instance.BBs[i].transform.SetParent(instance.BBGrid.transform);//��������������Ϊ������
                instance.BBs[i].GetComponent<BagButton>().BBID = i;//����������Ʒ����IDֵ
                instance.BBs[i].GetComponent<BagButton>().SetUpBB(instance.myBag.itemList[i]);
            }
        }
        
    }
}
