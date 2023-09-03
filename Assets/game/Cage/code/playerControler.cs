using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    Vector2 moveDir;

    public LayerMask detectLayer;
    Transform BOXtransform, BoxDefTransform;
    private AudioSource audioSource;
    public AudioClip click;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BOXtransform = GameObject.FindGameObjectWithTag("BOX").GetComponent<Transform>();
        BoxDefTransform = GameObject.FindGameObjectWithTag("BOX").transform.parent;
    }

    void Update()
    {
        if (!Static.isPause)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioSource.PlayOneShot(click);
                moveDir = Vector2.right;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioSource.PlayOneShot(click);
                moveDir = Vector2.left;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(click);
                moveDir = Vector2.up;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(click);
                moveDir = Vector2.down;
            }

            if (moveDir != Vector2.zero)
            {
                if (CanMoveToDir(moveDir))
                {
                    Move(moveDir);
                }
            }
            moveDir = Vector2.zero;
        }
    }

    bool CanMoveToDir(Vector2 Dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Dir, 1f, detectLayer);

        if (!hit) return true;
        else
        {
            if (hit.collider.GetComponent<Box>() != null)
                hit.collider.GetComponent<Box>().CanMoveToDir(Dir);
        }

        return false;


    }

    void Move(Vector2 Dir)
    {
        transform.Translate(Dir);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("BOX"))
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("BOX")||Input.GetButtonDown("PutDown"))
        {
            other.gameObject.transform.parent = BoxDefTransform;
        }
    }

}
