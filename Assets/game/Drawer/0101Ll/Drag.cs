using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler
{
    public Button button;
    public float buttonRedY;

    public Image imageToMove;
    private RectTransform imageRectTransform;
    private float imageStartY;
    private float imageStartX;

    public GameObject TurnButton;
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
        buttonRedY = buttonRectTransform.anchoredPosition.y;

        imageRectTransform = imageToMove.GetComponent<RectTransform>();
        imageStartY = imageRectTransform.anchoredPosition.y;
        imageStartX = imageRectTransform.anchoredPosition.x;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!Static.isPause)
        {
            float scrollDistance = eventData.delta.y;
            float targetY = imageRectTransform.anchoredPosition.y + scrollDistance;

            // 限制目标位置在一定范围内
            float minY = -415f;
            float maxY = imageStartY;
            targetY = Mathf.Clamp(targetY, minY, maxY);

            // 计算按钮位移
            float distance = buttonRedY - button.GetComponent<RectTransform>().anchoredPosition.y;
            Vector2 buttonDelta = new Vector2(0f, -scrollDistance + distance);

            // 更新图像和按钮的位置
            imageRectTransform.anchoredPosition = new Vector2(imageStartX, targetY);
            button.transform.Translate(buttonDelta, Space.World);

            if (imageRectTransform.anchoredPosition.y < -350f)
            {
                TurnButton.SetActive(true);
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                TurnButton.SetActive(false);
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}