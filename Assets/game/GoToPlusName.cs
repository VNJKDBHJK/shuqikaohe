using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPlusName : MonoBehaviour
{
    bool isShow;
    public int size;
    public string Name;
    public string SceneName;
    public string DisplayName;

    private void Start()
    {
        isShow = false;
    }

    private void Update()
    {
        if(!Static.isPause)
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clicjPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clicjPosition, Vector2.zero);
            if (hit.collider!=null&&hit.collider.gameObject.layer == LayerMask.NameToLayer("TurnTo"))
                if (hit.collider != null && hit.collider.gameObject.name == Name)
            {

                var hitObj = hit.collider.gameObject;
                SceneManager.LoadScene(SceneName);
            }
        }
    }

    private void OnMouseEnter()
    {
        isShow = true;
    }

    private void OnMouseExit()
    {
        isShow = false;
    }

    private void OnGUI()
    {
        if (isShow)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = size;
            style.normal.textColor = Color.grey;
            GUI.Label(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), DisplayName, style);
        }
    }
}
