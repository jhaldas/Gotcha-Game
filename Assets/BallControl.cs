using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    public Transform player;
    public Vector3 launchVector;
    public Transform vacuumEntrance;
    bool isHeld;
    Vector3 offset;
    bool launch = false;
    public Rigidbody2D rb;
    public float launchPower = 2f;
    bool wasGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        isHeld = false;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if(isHeld)
        {
            this.transform.position = vacuumEntrance.transform.position;
            this.transform.rotation = vacuumEntrance.transform.rotation;
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 0.5f;
        }
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
            wasGrabbed = false;
            isHeld = false;
            launch = true;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "VacuumHitbox")
        {  
            isHeld = false;
        }
    }

    void Launch(Vector3 launchVector, float launchPower)
    {
        rb.velocity = launchVector * launchPower;
        print(launchVector * launchPower);
        launch = false;
    }
}
