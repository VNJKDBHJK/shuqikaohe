using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWord : MonoBehaviour
{
    public item thisItem;
    public Inventory playerInventory;
    public string Name;

    public AudioClip get;
    private AudioSource audioSource;
    private bool hasTriggeredAudio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasTriggeredAudio = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 clicjPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clicjPosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.name ==Name)
            {
                audioSource.PlayOneShot(get);
                var hitObj = hit.collider.gameObject;

                AddNewItem();
                Destroy(gameObject);
                hasTriggeredAudio = true;
            }
            
        }
    }

    void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            for(int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventoryManager.RefreshItem();
    }
}
