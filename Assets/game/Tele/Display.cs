using UnityEngine;
using TMPro;
public class Display : MonoBehaviour
{
    private static Display instance;//一般来说只能一个BUTTON对应一个TEXT(且两个脚本只能再一个物体上),但运用单例模式可以解决多物体调用一个脚本的情况

    public int[] numberArray;
    public TMP_Text targetText;

    public static Display Instance//确保只有一个实例
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Display>();//如果没有实例会找到改组件
                DontDestroyOnLoad(instance.gameObject);//确保实例不会被销毁
            }
            return instance;
        }
    }

    public void ShowText(int number)
    {
        if (!Static.isPause)
        {
            // 将数字添加到数组中
            if (numberArray == null)//是否被初始化
            {
                numberArray = new int[] { number };
            }
            else
            {
                int[] newArray = new int[numberArray.Length + 1];//创建长度+1的数组
                numberArray.CopyTo(newArray, 0);//CopyTo()将数组元素复制过来
                newArray[newArray.Length - 1] = number;//将最后一个元素赋给增加长度的那个元素
                numberArray = newArray;
            }

            // 将数组内容显示在目标Text组件上
            targetText.text = string.Join("  ", numberArray);//string.Join()字符串的复制
        }
    }

    public void RemoveLastElementFromArray()
    {
        if (!Static.isPause)
        {
            if (numberArray != null && numberArray.Length > 0)
            {
                int[] newArray = new int[numberArray.Length - 1];
                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] = numberArray[i];
                }
                numberArray = newArray;
            }

            targetText.text = string.Join("  ", numberArray);//string.Join()字符串的复制
        }
    }

    public void NullNumber()
    {
        if (!Static.isPause)
        {
            targetText.text = "Error!!!";
            numberArray = new int[] { 0 };
        }
    }
}