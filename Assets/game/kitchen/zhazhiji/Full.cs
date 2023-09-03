using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Full : MonoBehaviour
{
    public Sprite[] images;

    private bool[] bools=new bool[12];
    private bool[] boolsChecked = new bool[12];
    private int[] Nums=new int[4] {0,0,0,0};

    public int ID;

    // Update is called once per frame
    void Update()
    {
        if (!Static.isPause) { 
            bools[0] = Static.is101;
            bools[1] = Static.is102;
            bools[2] = Static.is103;
            bools[3] = Static.is104;

        bools[4] = Static.is201;
        bools[5] = Static.is202;
        bools[6] = Static.is203;
        bools[7] = Static.is204;

        bools[8] = Static.is301;
        bools[9] = Static.is302;
        bools[10] = Static.is303;
        bools[11] = Static.is304;

        if (ID == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (bools[i] == true && boolsChecked[i] == false)
                {
                    Nums[0]++;
                    boolsChecked[i] = true;
                }
            }
            if (Nums[0] == 2||Nums[0]==3)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[1];
            }
            else if (Nums[0] == 4)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[2];
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[0];
            }
        }

        if (ID == 1)
        {
            for (int i = 4; i < 8; i++)
            {
                if (bools[i] == true && boolsChecked[i] == false)
                {
                    Nums[1]++;
                    boolsChecked[i] = true;
                }
            }
            if (Nums[1] == 2||Nums[1]==3)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[4];
            }
            else if (Nums[1] == 4)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[5];
            }
            else
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = images[3];
            }
        }

            if (ID == 2)
            {
                for (int i = 8; i < 12; i++)
                {
                    if (bools[i] == true && boolsChecked[i] == false)
                    {
                        Nums[2]++;
                        boolsChecked[i] = true;
                    }
                }
                if (Nums[2] == 2 || Nums[2] == 3)
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[7];
                }
                else if (Nums[2] == 4)
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[8];
                }
                else
                {
                    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = images[6];
                }
            }
        }
    }
}
