using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public CharacterController2D playerMove;
	[SerializeField] private LayerMask m_WhatIsGround;

    void OnTriggerEnter2D(Collider2D theCollision)
    {
		//Debug.Log(theCollision);

        //Debug.Log(theCollision.gameObject.layer + " : " + m_WhatIsGround);
		if (theCollision.gameObject.tag == "Ground")
		{
            Debug.Log(theCollision);
			playerMove.SetGrounded(true);
		}
    }
    
    //consider when character is jumping .. it will exit collision.
    void OnTriggerExit2D(Collider2D theCollision)
    {
		if (theCollision.gameObject.tag == "Ground")
		{
			playerMove.SetGrounded(false);
		}
    }
}
