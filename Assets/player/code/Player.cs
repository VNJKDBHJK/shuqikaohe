using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed,sspeed,Speed;
    public int jumpCount=2;
    public float jumpForce;
    bool isjump=false;

    Rigidbody2D rb;
    Animator anim;
    Collider2D coll;
    public AnimationCurve anicur;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        sspeed = speed + speed / 3;
        Speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Debug.Log(rb.velocity.y>0);
        if (isjump == false)
        {
            jumpCount = 2;
            anim.SetBool("jump3", false);
            anim.SetBool("idle", true);
        }
        Slid();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //使得移动在-1,1之间,改变人物面向方向
        float Horizontalmove = Input.GetAxis("Horizontal");
        float FaceDirection = Input.GetAxisRaw("Horizontal");
        //移动
        if (Horizontalmove != 0)
        {
            rb.velocity = new Vector2(Horizontalmove * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        anim.SetFloat("run", Mathf.Abs(FaceDirection));
        if (FaceDirection != 0) transform.localScale = new Vector3(FaceDirection, 1, 1);

    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            if (jumpCount == 2)
            {
                jumpCount--;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                if (rb.velocity.y >= 0) anim.SetBool("jump1", true);
            }else if (jumpCount == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetBool("jump1", false);
                anim.SetBool("jump2", true);
                jumpCount--;
            }else if (jumpCount == 0)
            {
                anim.SetBool("jump2", false);
                anim.SetBool("idle", true);
            }
        }
        if (rb.velocity.y < 3f && rb.velocity.y >= 0 && jumpCount == 1)
        {
            anim.SetBool("jump1", false);
            anim.SetBool("jump2", true);
        }
        if (rb.velocity.y < -0.1f)
        {
            anim.SetBool("jump2", false);
            anim.SetBool("jump3", true);
        }else if (rb.velocity.y > 0)
        {
            anim.SetBool("jump3", false);
            anim.SetBool("idle", true);
            isjump = true;
        }
        else
        {
            isjump = false;
        }
    }

    void Slid()
    {
        if (Input.GetButtonDown("slid"))
        {
            anim.SetBool("idle", false);
            anim.SetBool("slid", true);
            speed = sspeed;
        }
        if(Input.GetButtonDown("Upslid"))
        {
            anim.SetBool("slid", false);
            anim.SetBool("idle", true);
            speed = Speed;
        }
    }
}
