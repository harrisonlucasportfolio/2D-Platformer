using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed; 
   // public float maxSpeed; 
    public float jumpHeight;
    public bool grounded;
    public bool canDoubleJump;

    private Rigidbody2D rb2d;
    private Animator anim;


    // Use this for initialization
    void Start ()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update ()
    {
        anim.SetBool("grounded", grounded);
        anim.SetFloat("moveSpeed", Math.Abs(rb2d.velocity.x));


        // Jump
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W))
        {
            if(grounded)
            {
                //rb2d.AddForce(Vector2.up * jumpHeight);
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
                canDoubleJump = true;
                print(canDoubleJump);
            }
            else
            {
                if(canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
                    print(canDoubleJump);
                }
            }


        }

        // Move Left
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(Input.GetAxis("Horizontal") < -0.1f) // Left
            {
                if (transform.localScale.x > 0.1f) // Currently facing right, want to look left then move left
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
            rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);

        }

        // Move Right
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
            if(Input.GetAxis("Horizontal") > 0.1f) // Right
            {
                
                //print(transform.localScale.x);
                if (transform.localScale.x < -0.1f) // Currently facing left, want to look right then move right
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
            rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);

        }

    }
}
