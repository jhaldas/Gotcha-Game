using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmove : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Ball Speed Variables")]
    [SerializeField] private float ballAcceleration;
    [SerializeField] private float startSpeed;
    private float xDirection; // Horizontal
    private float yDirection; // Vertical

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * startSpeed;
    }
    
    private void Update()
    {
        xDirection = GetInput().x;
        yDirection = GetInput().y;
    }

    private void FixedUpate()
    {
        //ballMovement();
    }

    private static Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void ballMovement()
    {
            startSpeed += Time.deltaTime * ballAcceleration;
            rb.velocity = -transform.forward * startSpeed;
    }

}
