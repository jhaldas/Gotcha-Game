using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumAim : MonoBehaviour
{   
    public Transform vacuum;
    public Transform vacuumEntrance;

    float offset = -90;
    [SerializeField] private float rotSpeed = 3f;

    public Transform center;
    public bool facingRight = true;

    public Animator anim;

    public float currentPoints = 0;
    public float maxSuck = 5f;
    public float suckLeft;
    public float suckRegenRate;
    public float suckDepletionRate;
    public bool isSucking;
    public Transform suckMeter;
    bool holdingBall = false;

    public KeyCode clockwiseButton = KeyCode.V;
    public KeyCode counterClockwiseButton = KeyCode.C;
    public KeyCode suckButton = KeyCode.Space;
    public Coroutine cooldownCoroutine;
    public float cooldownTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        isSucking = false;
        suckLeft = maxSuck;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        // For rotating vacuum with mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = vacuum.position - mousePos;
        Quaternion val = Quaternion.LookRotation(Vector3.forward, perpendicular);
        val *= Quaternion.Euler(0, 0, offset);
        vacuum.rotation = val;
        */

        if(Input.GetKey(suckButton))
        {
            DepleteSuck();
        }
        else
        {
            RegenSuck();
            anim.SetBool("isSucking", false);
        }

        if(Clockwise())
        {
            vacuum.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
        }
        else if(CounterClockwise())
        {
            vacuum.transform.Rotate(Vector3.forward *rotSpeed * Time.deltaTime);
        }
        else
        {
            vacuum.transform.Rotate(Vector3.zero);
        }

        if(vacuumEntrance.transform.position.x > center.transform.position.x)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }

        if(suckLeft < 0)
        {
            suckLeft = 0;
        }
        suckMeter.transform.localScale = new Vector3(1f, suckLeft/maxSuck);

        //Debug.Log("Vacuum X: " + vacuumEntrance.transform.position.x + " | " + "Center X: " + center.transform.position.x);
    }


    bool Clockwise()
    {
        if (Input.GetKey(clockwiseButton))
        {
            return true;
        }
        return false;
    }

    bool CounterClockwise()
    {
        if (Input.GetKey(counterClockwiseButton))
        {
            return true;
        }
        return false;
    }

    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ball")
        {
            if(Input.GetKey(suckButton) && suckLeft > 0)
            {
                BallControl bc = collisionInfo.GetComponent<BallControl>();
                bc.isHeld = true;
                holdingBall = true;
            }
            else if(collisionInfo.GetComponent<BallControl>().isHeld == true)
            {
                BallControl bc = collisionInfo.GetComponent<BallControl>();
                bc.isHeld = false;
                bc.launch = true;
                holdingBall = false;
            }

        }
    }
    public void RegenSuck()
    {
        if(cooldownTimer <= 0)
        {
            if(suckLeft < maxSuck)
            {
                suckLeft += suckRegenRate * Time.deltaTime;  
            }
            else
            {
                suckLeft = maxSuck;
            }
        }
    }

    public void DepleteSuck()
    {
        cooldownTimer = 2;
        if(cooldownCoroutine != null)
        {
            StopCoroutine(cooldownCoroutine);
        }
        cooldownCoroutine = StartCoroutine(Cooldown(2));

        if(suckLeft > 0)
        {
            suckLeft -= suckDepletionRate * Time.deltaTime;
            if(!holdingBall)
            {
                anim.SetBool("isSucking", true);
            }else
            {
                anim.SetBool("isSucking", false);
            }
        }
        else
        {
            anim.SetBool("isSucking", false);
            suckLeft = 0;
        }
    }

    private IEnumerator Cooldown(float duration)
    {
        print("Duration: " + duration);
        while(duration > 0)
        {
            yield return new WaitForSeconds(1f);

            duration--;

            cooldownTimer = duration;
        }
    }
}
