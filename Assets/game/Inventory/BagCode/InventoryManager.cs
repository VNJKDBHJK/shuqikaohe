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
        instance = this;//将Canvas设置为单例
    }

    private void OnEnable()
    {
        RefreshItem();
        if(instance!=null)
        instance.itemInformation.text = "";
    }

    //将每个物品的TEXT传入
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    //
    public static void RefreshItem()
    {
        if(instance != null)
        {
            for (int i = 0; i < instance.BBGrid.transform.childCount; i++)//i<队列最大值
            {
                if (instance.transform.childCount == 0)//空队列
                    break;

                Destroy(instance.BBGrid.transform.GetChild(i).gameObject);//销毁子物体
                instance.BBs.Clear();//清空队列
            }

            for (int i = 0; i < instance.myBag.itemList.Count; i++)
            {
                instance.BBs.Add(Instantiate(instance.EmptyBB)); instance.BBs.Add(Instantiate(instance.EmptyBB));
                instance.BBs[i].transform.SetParent(instance.BBGrid.transform);//将队列中物体设为父物体
                instance.BBs[i].GetComponent<BagButton>().BBID = i;//将队列中物品赋予ID值
                instance.BBs[i].GetComponent<BagButton>().SetUpBB(instance.myBag.itemList[i]);
            }
        }
        
    }
}
