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

        if(Input.GetKey(KeyCode.A))
        {
            horizontalMove = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove = 1;
        }
        else
        {
            horizontalMove = 0;
        }
        //horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }

        controller.Move(horizontalMove, false, jump);
        jump = false;
    }
        
}
