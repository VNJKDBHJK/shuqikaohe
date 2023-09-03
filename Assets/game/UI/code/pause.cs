using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    private int ClickNums=0;
    public GameObject[] games;

    public Button button;
    public Sprite[] images;
    private Image ButtonImage;
    // Start is called before the first frame update
    void Start()
    {
        ButtonImage = button.GetComponent<Image>();
        ButtonImage.sprite = images[0];
        foreach (GameObject game in games)
        {
            game.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseOnClick()
    {
        /*Collider2D clickedCollider = GetClickedCollider();
        if (clickedCollider != null)
        {
            if (clickedCollider.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                if (clickedCollider.gameObject.tag == "Control")
                {*/
                    ClickNums++;
                    if (ClickNums % 2 == 1)
                    {
                        ButtonImage.sprite = images[1];
                        foreach (GameObject game in games)
                        {
                            game.SetActive(true);
                        }
                         Static.isPause = true;
                    }
                    else
                    {
                        ButtonImage.sprite = images[0];
                        foreach (GameObject game in games)
                        {
                            game.SetActive(false);
                        }
                        Static.isPause = false;
                    }
                /*}
            }
        }*/
        
    }

    private Collider2D GetClickedCollider()
    {
        // 发射一条射线，并获取点击的碰撞体
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            // 检查点击的对象是否有碰撞体
            Collider2D clickedCollider = hit.transform.GetComponent<Collider2D>();
            if (clickedCollider != null)
            {
                // 如果有碰撞体，则返回
                return clickedCollider;
            }
        }
        return null;
    }
}
