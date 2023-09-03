using UnityEngine;
using TMPro;
public class Display : MonoBehaviour
{
    private static Display instance;//һ����˵ֻ��һ��BUTTON��Ӧһ��TEXT(�������ű�ֻ����һ��������),�����õ���ģʽ���Խ�����������һ���ű������

    public int[] numberArray;
    public TMP_Text targetText;

    public static Display Instance//ȷ��ֻ��һ��ʵ��
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Display>();//���û��ʵ�����ҵ������
                DontDestroyOnLoad(instance.gameObject);//ȷ��ʵ�����ᱻ����
            }
            return instance;
        }
    }

    public void ShowText(int number)
    {
        if (!Static.isPause)
        {
            // ��������ӵ�������
            if (numberArray == null)//�Ƿ񱻳�ʼ��
            {
                numberArray = new int[] { number };
            }
            else
            {
                int[] newArray = new int[numberArray.Length + 1];//��������+1������
                numberArray.CopyTo(newArray, 0);//CopyTo()������Ԫ�ظ��ƹ���
                newArray[newArray.Length - 1] = number;//�����һ��Ԫ�ظ������ӳ��ȵ��Ǹ�Ԫ��
                numberArray = newArray;
            }

            // ������������ʾ��Ŀ��Text�����
            targetText.text = string.Join("  ", numberArray);//string.Join()�ַ����ĸ���
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

            targetText.text = string.Join("  ", numberArray);//string.Join()�ַ����ĸ���
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