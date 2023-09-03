using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowTurn : MonoBehaviour
{
    public string Name;
    public string SceneName;
    private void Update()
    {
        if (!Static.isPause)
            if (Static.isopenWindow0104)
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 clicjPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(clicjPosition, Vector2.zero);
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("TurnTo"))
                        if (hit.collider != null && hit.collider.gameObject.name == Name)
                        {
                            var hitObj = hit.collider.gameObject;
                            SceneManager.LoadScene(SceneName);
                        }
                }
    }
}
