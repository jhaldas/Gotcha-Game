using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumAim : MonoBehaviour
{   
    public Transform vacuum;
    float offset = -90;
    float rotSpeed =3f;

    private Transform aimTransform;

    // Start is called before the first frame update
    void Start()
    {
        aimTransform = transform.Find("Aim");
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

        if(Clockwise())
        {
            vacuum.transform.Rotate(Vector3.forward * -rotSpeed);
        }
        else if(CounterClockwise())
        {
            vacuum.transform.Rotate(Vector3.forward *rotSpeed);
        }
        else
        {

        }

    }

    bool Clockwise()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    }

    bool CounterClockwise()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return true;
        }
        return false;
    }
}
