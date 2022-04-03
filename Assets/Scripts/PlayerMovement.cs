using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 1f;
    float horizontalMove = 0f;
    bool jump = false;

    public GameController gameController;
    public Rigidbody2D rb;

    public Animator anim;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(gameController.gameStarted == true){
            rb.gravityScale = 3;
            if(Input.GetKey(leftKey))
            {
                horizontalMove = -1;
                anim.SetBool("Running", true);
                anim.SetBool("Idle", false);
            }
            else if (Input.GetKey(rightKey))
            {
                horizontalMove = 1;
                anim.SetBool("Running", true);
            }
            else
            {
                horizontalMove = 0;
                anim.SetBool("Idle", true);
                anim.SetBool("Running", false);
            }
        //horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

            if (Input.GetKeyDown(jumpKey))
            {
                jump = true;
            }

            controller.Move(horizontalMove, false, jump);
            jump = false;


            if(rb.velocity.y > 0)
            {
                anim.SetBool("Ascending", true);
                anim.SetBool("Descending", false);
            }
            else if(rb.velocity.y < 0)
            {
                anim.SetBool("Descending", true);
                anim.SetBool("Ascending", false);
            }
            else if(rb.velocity.y == 0)
            {
                anim.SetBool("Descending", false);
                anim.SetBool("Ascending", false);
            }
        }

        else
        {
            rb.gravityScale = 0;
        }
    }
        
}
