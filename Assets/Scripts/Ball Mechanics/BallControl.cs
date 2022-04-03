using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    public Transform player;
    public Collider2D playerHitBox;
    public Vector3 launchVector;
    public Transform vacuumEntrance;
    public bool isHeld;
    Vector3 offset;
    public bool launch = false;
    public Rigidbody2D rb;
    [SerializeField] private float launchPower = .2f;
    public bool wasGrabbed = false;
    Collider2D thisCollider;
    public GameController gameController;
    public float speedIncrease;

    // Start is called before the first frame update
    void Start()
    {
        isHeld = false;
        rb = this.GetComponent<Rigidbody2D>();
        thisCollider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if(isHeld)
        {
            this.transform.position = vacuumEntrance.transform.position;
            //this.transform.rotation = vacuumEntrance.transform.rotation;
        }
        else
        {
            rb.gravityScale = 0;
        }

        launchPower = launchPower + speedIncrease * Time.deltaTime;


    }
    void FixedUpdate()
    {
        if(launch == true)
        {
            launchVector = (this.transform.position - player.transform.position);
            //Debug.Log(launchVector);
            Launch(launchVector, launchPower);
        }
    }
/*
    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        Debug.Log("Bro");
        if(collisionInfo.gameObject.tag == "VacuumHitbox" && Input.GetKey(KeyCode.Space))
        {
            isHeld = true;
            wasGrabbed = true;
        }
        else if(wasGrabbed == true)
        {
            isHeld = false;
            launch = true;
        }
    }
    */

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player 1")
        {  
            gameController.player2Scores();
        }
        if(collisionInfo.gameObject.tag == "Player 2")
        {  
            gameController.player1Scores();
        }
    }

    void Launch(Vector3 launchVector, float launchPower)
    {
        rb.velocity = launchVector * launchPower;
        print(launchVector * launchPower);
        launch = false;
    }
}
