using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 1f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        controller.Move(horizontalMove, false, jump);
        jump = false;
    }

    void FixedUpdate()
    {

        
    }
}
