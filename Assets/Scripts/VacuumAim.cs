using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumAim : MonoBehaviour
{   
    public Transform vacuum;
    float offset = -90;
    private float rotSpeed = 3f;

    // Start is called before the first frame update

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
            vacuum.transform.Rotate(Vector3.zero);
        }

    }

    bool Clockwise()
    {
        if (Input.GetKey(KeyCode.V))
        {
            return true;
        }
        return false;
    }

    bool CounterClockwise()
    {
        if (Input.GetKey(KeyCode.C))
        {
            return true;
        }
        return false;
    }
}
