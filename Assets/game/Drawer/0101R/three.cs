using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class three : MonoBehaviour
{
    public LayerMask hitLayer;
    public string objectName;

    private RaycastHit2D hit;
    private Collider2D hitCollider;

    public AudioClip unlock;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector2 rayDirection = Vector2.down;
        hit = Physics2D.Raycast(transform.position, rayDirection, 1000, hitLayer);

        if (hit)
        {
            hitCollider = hit.collider;
            string hitObjectName = hitCollider.gameObject.name;

            if (hitObjectName == objectName)
            {
                Static.isthree = true;
                Destroy(gameObject);
                audioSource.PlayOneShot(unlock);
            }
            else
            {
                Static.isthree = false;
            }
        }
    }
}
