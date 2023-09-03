using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class number : MonoBehaviour
{
    public Texture2D[] pngArray;
    public Button button;

    public int currentIndex = 0;

    void Start()
    {
        SetButtonImage();
    }

    public void NextImage()
    {
        // 切换到下一个图像
        currentIndex++;
        if (currentIndex >= pngArray.Length)
        {
            currentIndex = 0;
        }

        SetButtonImage();
    }

    public void SetButtonImage()
    {
        if (button != null && pngArray.Length > 0)
        {
            Texture2D currentTexture = pngArray[currentIndex];
            Sprite sprite = Sprite.Create(currentTexture, new Rect(0, 0, currentTexture.width, currentTexture.height), new Vector2(0.5f, 0.5f));

            button.image.sprite = sprite;
        }
    }
}
