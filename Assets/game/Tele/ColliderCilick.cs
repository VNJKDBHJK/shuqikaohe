using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCilick : MonoBehaviour
{
    public LayerMask Layer;

    public GameObject page01;
    public GameObject Page1;
    public GameObject page02;
    public GameObject Page2;
    public GameObject page03;
    public GameObject Page3;
    public GameObject page04;
    public GameObject Page4;

    public bool ispage1;
    public bool ispage2;
    public bool ispage3;
    public bool ispage4;
    // Start is called before the first frame update
    void Start()
    {
        page01.SetActive(true);
        Page1.SetActive(false);
        page02.SetActive(false);
        Page2.SetActive(true);
        page03.SetActive(false);
        Page3.SetActive(true);
        page04.SetActive(false);
        Page4.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clicjPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clicjPosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.layer == Layer)
            {
                
                
            }
        }
    }
}
